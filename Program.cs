using System;
using System.CommandLine;
using System.Diagnostics;
using System.IO;

namespace Celones.MicrosoftKeyTool
{
    public static class Cruncher
    {
        public static int Main(string[] args)
        {
            var patternArgument = new Argument<string>(
                name: "pattern",
                description: "Microsoft product key pattern");

            var configOption = new Option<FileInfo>(
                name: "--config",
                description: "XrML key configuration file",
                getDefaultValue: () => new FileInfo("pkeyconfig.xrm-ms"));

            var cmd = new RootCommand("Microsoft product key cruncher");
            cmd.Add(patternArgument);
            cmd.Add(configOption);
            cmd.SetHandler((config, key) => Crunch(config, key), configOption, patternArgument);

            return cmd.Invoke(args);
        }

        internal static int Crunch(FileInfo config, string pattern)
        {
            var generator = new KeyGenerator(pattern);

            var stopwatch = Stopwatch.StartNew();
            for (int i = 1; i <= generator.PossibilitiesCount; i++)
            {
                var key = generator.GetNext();
                Console.Write(key);
                var status = Interop.Adapter.DecodeKey(key, config.FullName, "XXXXX", out var pid, out var digPid, out var digPid4);
                Console.WriteLine(" - {0}", status.ToString());

                var elapsed = stopwatch.Elapsed;
                var pace = elapsed / i;
                var left = (generator.PossibilitiesCount - i) * pace;
                Console.WriteLine("{0:dd\\.hh\\:mm\\:ss}, {1}/{2}, ETA: {3:dd\\.hh\\:mm\\:ss}", elapsed, i, generator.PossibilitiesCount, left);
                Console.WriteLine();
            }

            return 0;
        }
    }
}
