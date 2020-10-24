using System.Linq;
using Caliburn.Micro;
using Ccr.Gematria.Calculator.Infrastructure;
using Ccr.Gematria.Extensions;
using Ccr.Gematria.Models;
using Ccr.MaterialDesign.MVVM;

namespace Ccr.Gematria.ViewModels
{
	public class RootViewModel 
		: ViewModelBase
	{
		private string _phrase = "";
		private BindableCollection<GematriaCypherResult> _gematriaCypherResults;


		public string Phrase
		{
			get => _phrase;
			set
			{
				_phrase = value;
				NotifyOfPropertyChange(() => Phrase);

				onPhraseChanged(_phrase);
			}
		}
		
		public BindableCollection<GematriaCypherResult> GematriaCypherResults
		{
			get => _gematriaCypherResults;
			set
			{
				_gematriaCypherResults = value;
				NotifyOfPropertyChange(() => GematriaCypherResults);
			}
		}


		public RootViewModel()
		{
			onPhraseChanged("");
		}


		private void onPhraseChanged(string phrase)
		{
			GematriaCypherResults = CypherProvider
				.AllCyphers
				.Select(t => new GematriaCypherResult(t, GematriaCalculator.Calculate(t, phrase)))
				.ToBindable();
		}
	}
}
