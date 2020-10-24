using System.Linq;

namespace Ccr.Gematria.Calculator.Infrastructure
{
	public sealed class GematriaCalculator
	{
		public static int Calculate<TCypher>(string text)
			where TCypher : ICypher, new()
		{
			var cypher = CypherProvider.GetCypherInstance<TCypher>();

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