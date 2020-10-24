using System.Collections.Generic;
using Ccr.Gematria.Calculator.Infrastructure;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public class ValueMapCypher
		: ICypher
	{
		public IReadOnlyDictionary<char, int> ValueTable { get; }

		public string Name { get; }

		public string Category { get; }

		public bool IsExperimental { get; }

		public bool IsUserDefined => true;

		public int[] RGBColor => new[] { 55, 255, 67 };


		public ValueMapCypher(
			string name,
			string category,
			bool isExperimental,
			IReadOnlyDictionary<char, int> valueTable )
		{
			Name = name;
			Category = category;
			IsExperimental = isExperimental;
			ValueTable = valueTable;
		}


		public int GetValue(char @char)
		{
			if (ValueTable.TryGetValue(@char, out var value))
				return value;

			return 0;
		}
	}
}
