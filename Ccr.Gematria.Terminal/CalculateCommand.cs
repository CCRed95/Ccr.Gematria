using System;
using Ccr.Colorization.Mappings;
using Ccr.Gematria.Calculator.Cyphers;
using Ccr.Gematria.Calculator.Infrastructure;
using static Ccr.Terminal.ExtendedConsole;

namespace Ccr.Gematria.Terminal
{
	public class CalculateCommand
		: TerminalCommand<string>
	{
		public override string CommandName => "calculate";

		public override string ShortCommandName => "calc";


		public override void Execute(string args)
		{
			XConsole.Write("Text: ", Swatch.Cyan);
			var text = Console.ReadLine();

			var englishOrdinal = GematriaCalculator.Calculate<EnglishOrdinalCypher>(text);
			var reverseOrdinal = GematriaCalculator.Calculate<ReverseOrdinalCypher>(text);
			var fullReduction = GematriaCalculator.Calculate<FullReductionCypher>(text);
			var reverseFullReduction = GematriaCalculator.Calculate<ReverseFullReductionCypher>(text);
			var jewish = GematriaCalculator.Calculate<JewishCypher>(text);
			var fibonacciSequence = GematriaCalculator.Calculate<FibonacciSequenceCypher>(text);

			XConsole
				.Write($"    English Ordinal:           ", Swatch.Amber)
				.WriteLine($"{englishOrdinal}", Swatch.Teal);

			XConsole
				.Write($"    Full Reduction:            ", Swatch.Amber)
				.WriteLine($"{reverseOrdinal}", Swatch.Teal);

			XConsole
				.Write($"    Full Reduction:            ", Swatch.Amber)
				.WriteLine($"{fullReduction}", Swatch.Teal);

			XConsole
				.Write($"    Reverse Full Reduction:    ", Swatch.Amber)
				.WriteLine($"{reverseFullReduction}", Swatch.Teal);

			XConsole
				.Write($"    Jewish:                    ", Swatch.Amber)
				.WriteLine($"{jewish}", Swatch.Teal);

			XConsole
				.Write($"    Fibonacci Sequence:        ", Swatch.Amber)
				.WriteLine($"{fibonacciSequence}", Swatch.Teal);


			Console.WriteLine();
		}
	}
}
