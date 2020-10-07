namespace Ccr.Gematria.Calculator.Cyphers
{
	public class ReverseOrdinalCypher
		: EnglishCypherBase
	{
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