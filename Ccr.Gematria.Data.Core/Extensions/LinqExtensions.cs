using System.Collections.Generic;
using System.Linq;
using Ccr.Std.Core.Extensions;
using JetBrains.Annotations;

namespace Ccr.Gematria.Data.Core.Extensions
{
	public static class LinqExtensions
	{
		public static HashSet<T> ToHashSet<T>(
			this IEnumerable<T> source,
			IEqualityComparer<T> comparer = null)
		{
			return new HashSet<T>(source, comparer);
		}

		public static IEnumerable<IEnumerable<TValue>> Chunk<TValue>(
			[NotNull, ItemNotNull] this IEnumerable<TValue> @this,
			int chunkSize)
		{
			@this.IsNotNull(nameof(@this));

			var pos = 0;
			while (@this.Skip(pos).Any())
			{
				yield return @this.Skip(pos).Take(chunkSize);
				pos += chunkSize;
			}
		}
	}
}
