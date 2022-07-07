namespace Celones.MicrosoftKeyTool
{
    public class KeyChecker
    {
        private readonly string m_pkeyConfig;

        public KeyChecker(string config)
        {
            m_pkeyConfig = config;
        }

        public bool IsValid(string key, out string description)
        {
            var result = Interop.Adapter.DecodeKey(key, m_pkeyConfig, "XXXXX", out var pid, out var digPid, out var digPid4);

            description = result.ToString();

            return result == KeyStatus.Valid;
        }
    }
}
