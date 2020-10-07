using System.Collections.Generic;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public static class Utilities
	{
		public static int[] GetDigits(int source)
		{
			var digits = new Stack<int>();
			while (source > 0)
			{
				var digit = source % 10;
				source /= 10;
				digits.Push(digit);
			}
			return digits.ToArray();
		}
	}
}