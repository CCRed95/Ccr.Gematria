using System;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class JewishCypher
		: EnglishCypherBase
	{
		public override int GetValue(char @char)
		{
			if (!char.IsLetter(@char))
				return 0;

			var indexInAlphabet = GetIndexInAlphabet(@char);

			if (@char >= 'a' && @char <= 'i')
			{
				return indexInAlphabet;
			}
			if (@char >= 'k' && @char <= 's')
			{

			}

			throw new NotImplementedException();
		}
	}
}