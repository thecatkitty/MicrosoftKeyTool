using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace Celones.MicrosoftKeyTool
{
    public class KeyChecker
    {
        private struct ProductConfiguration
        {
            public string EditionId;
            public string ProductDescription;
        }

        private readonly string m_pkeyConfig;
        private readonly Dictionary<Guid, ProductConfiguration> m_productDescriptions;

        public KeyChecker(string config)
        {
            m_pkeyConfig = config;

            var xml = new XmlDocument();
            xml.Load(config);

            var base64 = xml.GetElementsByTagName("tm:infoBin")[0]?.InnerText ?? string.Empty;
            using (var stream = new MemoryStream(Convert.FromBase64String(base64)))
            {
                xml = new XmlDocument();
                xml.Load(stream);
            }

            var ns = new XmlNamespaceManager(xml.NameTable);
            ns.AddNamespace("pkc", "http://www.microsoft.com/DRM/PKEY/Configuration/2.0");

            m_productDescriptions = new Dictionary<Guid, ProductConfiguration>();
            var configurations = xml.SelectNodes("/pkc:ProductKeyConfiguration/pkc:Configurations/pkc:Configuration", ns)?.Cast<XmlElement>();
            foreach (var configuration in configurations ?? Enumerable.Empty<XmlElement>())
            {
                var actConfigId = configuration.GetElementsByTagName("pkc:ActConfigId").OfType<XmlElement>().First();
                var editionId = configuration.GetElementsByTagName("pkc:EditionId").OfType<XmlElement>().First();
                var productDescription = configuration.GetElementsByTagName("pkc:ProductDescription").OfType<XmlElement>().First();

                m_productDescriptions.Add(new Guid(actConfigId.InnerText), new ProductConfiguration
                {
                    EditionId = editionId.InnerText,
                    ProductDescription = productDescription.InnerText
                });
            }
        }

        public string? GetProductDescription(string activationId, string editionId)
        {
            var guid = new Guid(activationId);
            if (!m_productDescriptions.ContainsKey(guid))
            {
                return null;
            }

            var configuration = m_productDescriptions[guid];
            if (configuration.EditionId.Contains(editionId))
            {
                return configuration.ProductDescription;
            }

            return null;
        }

        public bool IsValid(string key, out string description)
        {
            var result = Interop.Adapter.DecodeKey(key, m_pkeyConfig, "XXXXX", out var pid, out var digPid, out var digPid4);

            if (result == KeyStatus.Valid)
            {
                description = GetProductDescription(digPid4.ActivationId, digPid4.EditionType) ?? "No Edition Info";
            } else {
                description = result.ToString();
            }

            return result == KeyStatus.Valid;
        }
    }
}
