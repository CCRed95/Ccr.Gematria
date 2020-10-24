using Ccr.Gematria.Calculator.Infrastructure;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class ReverseOrdinalCypher
		: EnglishCypherBase
	{
		public override string Name => "Reverse Ordinal";

		public override int[] RGBColor => new[] { 255, 145, 0 };


		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);
			var reverseIndex = 27 - indexInAlphabet;
			return reverseIndex;
		}
	}
}