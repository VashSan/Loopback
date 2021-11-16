using System;
using CommandLine;

namespace Loopback
{
    public class LoopbackOptions
	{
		[Option('x', "exitcode", Default = (int)0, Required = false, HelpText = "Loopback returns specified exitcode. Defaults to 0.")]
		public int ExitCode { get; set; }

		[Option('e', "error", Default = (string)"", Required = false, HelpText = "Writes the specified text to the default out. Is written after output. Will replace \\n by newlines.")]
		public string Error { get; set; }

		[Option('o', "output", Default = (string)"", Required = false, HelpText = "Writes the specified text to the error out. Has precedence before error. Will replace \\n by newlines.")]
		public string Output { get; set; }
	}
}
