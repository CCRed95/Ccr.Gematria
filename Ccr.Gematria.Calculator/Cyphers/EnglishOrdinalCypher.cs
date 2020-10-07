namespace Ccr.Gematria.Calculator.Cyphers
{
	public class EnglishOrdinalCypher
		: EnglishCypherBase
	{
		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);
			return indexInAlphabet;
		}
	}
}
