using System.Collections.Generic;
using System.Collections.ObjectModel;
using Caliburn.Micro;

namespace Ccr.Gematria.Extensions
{
	public static class EnumerableExtensions
	{
		public static ObservableCollection<TValue> ToObservable<TValue>(
			this IEnumerable<TValue> @this)
		{
			return new ObservableCollection<TValue>(
				@this);
		}
		
		public static BindableCollection<TValue> ToBindable<TValue>(
			this IEnumerable<TValue> @this)
		{
			return new BindableCollection<TValue>(
				@this);
		}
	}
}
