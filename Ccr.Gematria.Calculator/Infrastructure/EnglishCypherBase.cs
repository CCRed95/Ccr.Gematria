using System;
using Ccr.Std.Core.Extensions;
using Ccr.Std.Core.Extensions.NumericExtensions;

namespace Ccr.Gematria.Calculator.Infrastructure
{
	public abstract class EnglishCypherBase
		: ICypher
	{
		public abstract string Name { get; }

		public virtual string Category { get; } = "Default";

		public virtual bool IsExperimental { get; } = false;

		public virtual bool IsUserDefined { get; } = false;

		public abstract int[] RGBColor { get; }


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