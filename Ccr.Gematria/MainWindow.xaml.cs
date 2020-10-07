using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Ccr.Gematria.Calculator.Cyphers;
using Ccr.Gematria.Data.Context;
using Ccr.Gematria.Data.Domain;

namespace Ccr.Gematria
{
	public class DictionaryReader
	{
		private const string _dictionaryPath =
			@"C:\Repositories\Ccr.Gematria\Dictionaries\wlist_match12.txt";


		public DictionaryReader()
		{

		}


		public async IAsyncEnumerable<string> GetWordsAsync()
		{
			using var reader = File.OpenText(_dictionaryPath);

			while (!reader.EndOfStream)
			{
				yield return await reader.ReadLineAsync();
			}
		}

		public IEnumerable<string> GetWords()
		{
			using var reader = File.OpenText(_dictionaryPath);

			while (!reader.EndOfStream)
			{
				yield return reader.ReadLine();
			}
		}
	}
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		private const string _dictionaryPath =
			@"C:\Repositories\Ccr.Gematria\Dictionaries\wlist_match12.txt";


		public MainWindow()
		{
			InitializeComponent();

			Console.WriteLine("Ccr Gematria Calculator");
			//Console.WriteLine($"  Cypher: {nameof(FibonacciSequenceCypher)}");

			var quit = false;

			while (!quit)
			{
				Console.Write("Enter input text: ");
				var text = Console.ReadLine();

				switch (text)
				{
					case "q":
					case "quit":
					case "exit":
						{
							quit = true;
							break;
						}
					case "fib":
						{
							var cypher = new FibonacciSequenceCypher();

							for (var c = 'a'; c <= 'z'; c++)
							{
								var value = cypher.GetValue(c);
								Console.WriteLine($"    {c} -> {value}");
							}

							break;
						}
					case "dictionary":
						{
							using var context = new CoreContext();
							var reader = new DictionaryReader();

							foreach (var word in reader.GetWords())
							{
								Console.WriteLine($"  Word: {word}");

								var englishOrdinal = GematriaCalculator.Calculate<EnglishOrdinalCypher>(word);
								var reverseOrdinal = GematriaCalculator.Calculate<ReverseOrdinalCypher>(word);
								var fullReduction = GematriaCalculator.Calculate<FullReductionCypher>(word);
								var reverseFullReduction = GematriaCalculator.Calculate<ReverseFullReductionCypher>(word);
								var jewish = GematriaCalculator.Calculate<JewishCypher>(word);
								var fibonacciSequence = GematriaCalculator.Calculate<FibonacciSequenceCypher>(word);
								
								Console.WriteLine($"    English Ordinal:           {englishOrdinal}");
								Console.WriteLine($"    Reverse Ordinal:           {reverseOrdinal}");
								Console.WriteLine($"    Full Reduction:            {fullReduction}");
								Console.WriteLine($"    Reverse Full Reduction:    {reverseFullReduction}");
								Console.WriteLine($"    Jewish:                    {jewish}");
								Console.WriteLine($"    Fibonacci Sequence:        {fibonacciSequence}");

								var gematriaResult = new GematriaResult
								{
									Text = word,
									EnglishOrdinal = englishOrdinal,
									ReverseOrdinal = reverseOrdinal,
									FullReduction = fullReduction,
									ReverseFullReduction = reverseFullReduction,
									Jewish = jewish,
									FibonacciSequence = fibonacciSequence
								};

								context.GematriaResults.Add(gematriaResult);
							}

							Console.Write("  Saving results to database... ");

							context.SaveChanges();

							Console.WriteLine("Complete!");

							break;
						}
					default:
						{
							var result = GematriaCalculator.Calculate<FibonacciSequenceCypher>(text);
							Console.Write($"    Total: {result}");
							Console.WriteLine();

							break;
						}
				}
			}
		}
	}
}
/*		*/
