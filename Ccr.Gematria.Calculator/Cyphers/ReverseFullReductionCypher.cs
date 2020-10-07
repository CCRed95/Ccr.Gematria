using System.Linq;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class ReverseFullReductionCypher
		: EnglishCypherBase
	{
		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);
			var reverseIndex = 27 - indexInAlphabet;

			var value = reverseIndex;
			var digits = Utilities.GetDigits(value);

			while (digits.Length > 1)
			{
				value = digits.Sum();
				digits = Utilities.GetDigits(value);
			}
			return value;
		}
	}
}