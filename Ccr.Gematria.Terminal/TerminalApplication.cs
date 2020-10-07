using System.Collections.Generic;
using System.Linq;
using Ccr.Colorization.Mappings;
using Ccr.Std.Core.Extensions;
using static Ccr.Terminal.ExtendedConsole;

namespace Ccr.Gematria.Terminal
{
	public abstract class TerminalApplication
	{
		private readonly string[] _args;


		public abstract string ApplicationName { get; }

		public abstract string VersionNumber { get; }

		protected string[] Args
		{
			get => _args;
		}


		public abstract IReadOnlyList<TerminalCommandBase> TerminalCommands { get; }
		//{
		//	get => _terminalCommands;
		//}

		public IReadOnlyDictionary<string, TerminalCommandBase> TerminalCommandNamesMapping
		{
			get => TerminalCommands
				.ToDictionary(
					t => t.CommandName,
					t => t);
		}

		public IReadOnlyDictionary<string, TerminalCommandBase> TerminalShortCommandNamesMapping
		{
			get => TerminalCommands
				.ToDictionary(
					t => t.ShortCommandName,
					t => t);
		}



		protected TerminalApplication(
			string[] args)
		{
			_args = args;
		}


		public void Start()
		{
			ApplicationProcess();
		}

		private void ApplicationProcess()
		{
			XConsole
				.AddUnderline()
				.SetBold()
				.WriteLine($"{ApplicationName} - version {VersionNumber}", Swatch.Pink)
				.RemoveUnderline()
				.SetNormalIntensity()
				.WriteLine()
				.WriteLine();

			var hasQuit = false;

			while (!hasQuit)
			{
				XConsole
					.Write("enter command: ", Swatch.Teal)
					.Write("", Swatch.Cyan);

				var command = XConsole.ReadLine();

				if (TerminalCommandNamesMapping.TryGetValue(command, out var commandBase))
				{
					commandBase.ExecuteBase("");
				}
				else if (TerminalShortCommandNamesMapping.TryGetValue(
					command,
					out var shortNameCommandBase))
				{
					shortNameCommandBase.ExecuteBase("");
				}
				else
				{
					if (command == "quit" || command == "exit")
					{
						XConsole
							.WriteLine($"Really quit? (Y/N): ", Swatch.Cyan);

						var result = XConsole.ReadLine();

						if (result?.ToUpper() == "Y")
						{
							hasQuit = true;
						}
					}
					else
					{
						XConsole
							.WriteLine($"{command.SQuote()} is not a recognized command.", Swatch.Red);
					}
				}
			}
		}
	}
}