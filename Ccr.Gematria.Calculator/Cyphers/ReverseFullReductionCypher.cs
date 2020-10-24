using System.Linq;
using Ccr.Gematria.Calculator.Infrastructure;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class ReverseFullReductionCypher
		: EnglishCypherBase
	{
		public override string Name => "Reverse Full Reduction";

		public override int[] RGBColor => new[] { 255, 234, 0 };


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