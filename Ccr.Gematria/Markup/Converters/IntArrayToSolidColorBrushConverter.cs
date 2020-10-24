using System.Linq;
using System.Windows.Media;
using Ccr.Xaml.Markup.Converters.Infrastructure;

namespace Ccr.Gematria.Markup.Converters
{
	public class IntArrayToSolidColorBrushConverter
		: XamlConverter<int[], NullParam, SolidColorBrush>
	{
		public override SolidColorBrush Convert(
			int[] arr, 
			NullParam param)
		{
			var ba = arr
				.Select(System.Convert.ToByte)
				.ToArray();

			return arr.Length switch
			{
				0 => new SolidColorBrush(Colors.White),
				1 => new SolidColorBrush(Color.FromRgb(ba[0], ba[0], ba[0])),
				3 => new SolidColorBrush(Color.FromRgb(ba[0], ba[1], ba[2])),
				4 => new SolidColorBrush(Color.FromArgb(ba[0], ba[1], ba[2], ba[3])),

				_ => null
			};
		}
	}
}
