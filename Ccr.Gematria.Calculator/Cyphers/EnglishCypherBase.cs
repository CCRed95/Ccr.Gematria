using System;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public abstract class EnglishCypherBase
		: ICypher
	{
		protected int GetIndexInAlphabet(char @char)
		{
			int integralCharValue = char.ToLower(@char);
			if (!integralCharValue.IsWithin(('a', 'z')))
				throw new NotSupportedException(
					$"The character {@char.SQuote()} is not valid because it is not a letter.");

			return integralCharValue - 'a' + 1;
		}

		public abstract int GetValue(char @char);
	}
}