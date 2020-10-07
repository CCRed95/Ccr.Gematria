using System.Linq;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public sealed class GematriaCalculator
	{
		public static int Calculate<TCypher>(string text)
			where TCypher : ICypher, new()
		{
			var cypher = new TCypher();

			var result = text.ToCharArray()
				.Select(t => cypher.GetValue(t))
				.Sum();

			return result;
		}

		public static int Calculate(
			ICypher cypher,
			string text)
		{
			var result = text.ToCharArray()
				.Select(cypher.GetValue)
				.Sum();

			return result;
		}
	}
}