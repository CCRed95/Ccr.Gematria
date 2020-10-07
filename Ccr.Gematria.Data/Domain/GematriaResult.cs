namespace Ccr.Gematria.Data.Domain
{
	public class GematriaResult
	{
		public int GematriaResultID { get; set; }

		public string Text { get; set; }

		public int EnglishOrdinal { get; set; }

		public int ReverseOrdinal { get; set; }

		public int FullReduction { get; set; }

		public int ReverseFullReduction { get; set; }

		public int Jewish { get; set; }

		public int FibonacciSequence { get; set; }
	}
}
