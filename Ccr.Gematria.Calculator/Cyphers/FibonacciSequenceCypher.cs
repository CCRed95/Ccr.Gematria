using System.Linq;
using Ccr.Gematria.Calculator.Infrastructure;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class FibonacciSequenceCypher
		: EnglishCypherBase
	{
		public override string Name => "Fibonacci Sequence";

		public override string Category => "Custom - Math";

		public override bool IsExperimental => true;

		public override int[] RGBColor => new[] { 245, 0, 87 };
		

		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);

			var fibonacci = GetNthFibonacci(indexInAlphabet);

			var value = fibonacci;
			var digits = Utilities.GetDigits(value);

			while (digits.Length > 1)
			{
				value = digits.Sum();
				digits = Utilities.GetDigits(value);
			}
			return value;
		}

		public static int GetNthFibonacci(int value)
		{
			if (value == 0 || value == 1)
				return value;

			return GetNthFibonacci(value - 1) + GetNthFibonacci(value - 2);
		}
	}
}