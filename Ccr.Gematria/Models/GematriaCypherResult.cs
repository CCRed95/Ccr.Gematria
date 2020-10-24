using Ccr.Gematria.Calculator.Infrastructure;

namespace Ccr.Gematria.Models
{
	public class GematriaCypherResult
	{
		public ICypher Cypher { get; set; }

		public int Value { get; set; }


		public bool HasPerfectSquare
		{
			get => PerfectSquare.HasValue;
		}

		public int? PerfectSquare { get; set; }


		public GematriaCypherResult()
		{
		}

		public GematriaCypherResult(
			ICypher cypher,
			int value)
		{
			Cypher = cypher;
			Value = value;

			if (Utilities.TryGetPerfectSquare(Value, out var sqrt))
			{
				PerfectSquare = sqrt;
			}
		}
	}
}