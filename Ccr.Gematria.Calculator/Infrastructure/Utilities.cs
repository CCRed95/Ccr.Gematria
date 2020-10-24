using System;
using System.Collections.Generic;

namespace Ccr.Gematria.Calculator.Infrastructure
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

		public static bool IsPrime(int number)
		{
			if (number == 1)
				return false;

			if (number == 2)
				return true;

			var limit = Math.Ceiling(Math.Sqrt(number));

			for (var i = 2; i <= limit; ++i)
			{
				if (number % i == 0)
					return false;
			}
			return true;
		}

		public static bool IsPerfectSquare(int number)
		{
			new int();

			var result = Math.Sqrt(number);
			return result % 1 == 0;
		}
		
		public static bool TryGetPerfectSquare(int number, out int sqrt)
		{
			if (IsPerfectSquare(number))
			{
				sqrt = (int)Math.Round(Math.Sqrt(number));
				return true;
			}
			
			sqrt = -1;
			return false;
		}
	}
}