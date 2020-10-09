using System;
using Ccr.Gematria.Calculator.Cyphers;

namespace Ccr.Gematria.Terminal
{
	public class FibonacciCommand 
		: TerminalCommand<string>
	{
		public override string CommandName => "fibonacci";

		public override string ShortCommandName => "fib";


		public override void Execute(string args)
		{
			Console.Write("Text: ");
			var text = Console.ReadLine();

			var result = GematriaCalculator.Calculate<FibonacciSequenceCypher>(text);

			Console.WriteLine($"{result}");
		}
	}
}
