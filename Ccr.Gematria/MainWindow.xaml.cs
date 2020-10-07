using System;
using Ccr.Gematria.Calculator.Cyphers;

namespace Ccr.Gematria
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow
	{
		public MainWindow()
		{
			InitializeComponent();

			Console.WriteLine("Ccr Gematria Calculator");
			Console.WriteLine("  Cypher: English Ordinal Cypher");
			
			var quit = false;

			while (!quit)
			{
				Console.Write("  Enter input text: ");
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
					default:
					{
						var result = GematriaCalculator.Calculate<EnglishOrdinalCypher>(text);
						Console.WriteLine($"    Total: {result}");
						Console.WriteLine();

						break;
					}
				}
			}
		}
	}
}
/*			var cypher = new FibonacciSequenceCypher();

			for (var c = 'a'; c <= 'z'; c++)
			{
				var value = cypher.GetValue(c);
				Console.WriteLine($"    {c} -> {value}");
			}*/
