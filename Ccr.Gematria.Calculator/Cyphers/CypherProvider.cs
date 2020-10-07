using System;
using System.Collections.Generic;
using Ccr.Std.Core.Extensions;

namespace Ccr.Gematria.Calculator.Cyphers
{
	public sealed class CypherProvider
	{
		private static readonly IDictionary<Type, ICypher> _cypherCache
			= new Dictionary<Type, ICypher>();

		
		public static ICypher GetCypherInstanceBase(Type cypherType)
		{
			if (_cypherCache.TryGetValue(cypherType, out var cypher))
				return cypher;

			var cypherCtor = cypherType.GetConstructor(new Type[] { });
			if (cypherCtor == null)
				throw new NotSupportedException(
					$"Cannot create instance of type {cypherType.FormatName().SQuote()} because it does not " +
					$"contain a parameterless constructor.");

			var cypherInstanceBoxed = cypherCtor.Invoke(null);

			if (!(cypherInstanceBoxed is ICypher cypherInstance))
			{
				throw new NotSupportedException(
					$"The type {cypherType.FormatName().SQuote()} must implement {nameof(ICypher).SQuote()}.");
			}
			_cypherCache.Add(cypherType, cypherInstance);
			return cypherInstance;
		}

		public static TCypher GetCypherInstance<TCypher>()
			where TCypher : ICypher, new()
		{
			if (_cypherCache.TryGetValue(typeof(TCypher), out var cypher))
				return cypher.As<TCypher>();

			var cypherInstance = new TCypher();
			_cypherCache.Add(typeof(TCypher), cypherInstance);

			return cypherInstance;
		}
	}
}