using System.Linq;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class FibonacciSequenceCypher
		: EnglishCypherBase
	{
		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);
			if (indexInAlphabet >= 25)
				return 1;

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