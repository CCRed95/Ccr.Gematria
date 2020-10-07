using System.Collections.Generic;

namespace Ccr.Gematria.Terminal
{
	public class GematriaTerminalApplication
		: TerminalApplication
	{
		public override string ApplicationName => "gematria terminal";

		public override string VersionNumber => "1.0.0.0";


		public override IReadOnlyList<TerminalCommandBase> TerminalCommands { get; }
			= new List<TerminalCommandBase>
			{
				new FibonacciCommand(),
			};


		public GematriaTerminalApplication(
			string[] args) : base(args)
		{
		}
	}
}