using Ccr.Gematria.Calculator.Infrastructure;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class EnglishOrdinalCypher
		: EnglishCypherBase
	{
		public override string Name => "English Ordinal";
		
		public override int[] RGBColor => new[] { 0, 230, 118 };


		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);
			return indexInAlphabet;
		}
	}
}
