using System;
using System.Collections.Generic;
using System.IO;
using CommandLine;

namespace Loopback
{
    class Program
    {
        static int Main(string[] args)
		{
			int result = Parser.Default
				.ParseArguments<LoopbackOptions>(args)
				.MapResult(
					(LoopbackOptions o) => LoopbackRunner.Run(o),
					HandleParseError);

			return result;
		}

		private static int HandleParseError(IEnumerable<Error> errors)
		{
            // We could attempt to return any magic code in case of an error.
            // But this program is not designed to be used in an automated pipeline, 
            // so we have to live with the default help output.
			return 0;
		}
    }

    public class LoopbackRunner {
        public static int Run(LoopbackOptions options) {
            WriteTextIfNotEmpty(options.Output, Console.Out);
            WriteTextIfNotEmpty(options.Error, Console.Error);
            return options.ExitCode;
        }

        private static void WriteTextIfNotEmpty(string text, TextWriter output) {
            if (!string.IsNullOrWhiteSpace(text)) {
                output.Write(text.Replace("\\n", "\n"));
            }
        }
    }
}
