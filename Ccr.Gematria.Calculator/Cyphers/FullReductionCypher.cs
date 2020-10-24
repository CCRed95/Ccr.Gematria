using System.Linq;
using Ccr.Gematria.Calculator.Infrastructure;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class FullReductionCypher
		: EnglishCypherBase
	{
		public override string Name => "Full Reduction";

		public override int[] RGBColor => new[] { 41, 121, 255 };


		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);

			var value = indexInAlphabet;
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