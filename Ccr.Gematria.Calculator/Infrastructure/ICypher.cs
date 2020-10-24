namespace Ccr.Gematria.Calculator.Infrastructure
{
	public interface ICypher
	{
		string Name { get; }

		string Category { get; }

		bool IsExperimental { get; }

		bool IsUserDefined { get; }

		int[] RGBColor { get; }
		


		int GetValue(char @char);
	}
}