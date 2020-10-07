using System;
using System.Runtime.InteropServices.ComTypes;

namespace Ccr.Gematria.Calculator.Cyphers
{
	//TODO finish this
	public class JewishCypher
		: EnglishCypherBase
	{
		public override int GetValue(char @char)
		{
			return char.ToLower(@char) switch
			{
				'a' => 1,
				'b' => 2,
				_ => 0;
			};

			//if (!char.IsLetter(@char))
			//	return 0;

			//var indexInAlphabet = GetIndexInAlphabet(@char);

			//if (@char >= 'a' && @char <= 'i')
			//{
			//	return indexInAlphabet;
			//}
			//if (@char >= 'k' && @char <= 's')
			//{
			//	return (indexInAlphabet - 10) * 10;
			//}

			//throw new NotImplementedException();
		}
	}
}