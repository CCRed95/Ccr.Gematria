using System;
using Ccr.Colorization.Mappings;
using Ccr.Std.Core.Extensions;
using static Ccr.Terminal.ExtendedConsole;

namespace Ccr.Gematria.Terminal
{
	public abstract class TerminalCommandBase
	{
		public abstract string CommandName { get; }

		public abstract string ShortCommandName { get; }


		public void ExecuteBase(
			object args = null)
		{
			var type = GetType();

			if (this is TerminalCommand command)
			{
				try
				{
					XConsole
						.Write($"Starting Command: ", Swatch.Cyan)
						.Write($"{CommandName.Quote()}", Swatch.Teal)
						.WriteLine(" with no arguments", Swatch.Cyan);

					command.Execute();
				}
				catch (Exception ex)
				{
					WriteExceptionToConsole(ex);
				}
			}
			else
			{
				var genericArguments = type.BaseType.GetGenericArguments();

				switch (genericArguments.Length)
				{
					case 0:
						throw new NotSupportedException(
							$"No generic arguments found on the Execute method.");

					case 1:
						{
							var expectedArgumentType = genericArguments[0];

							if (args == null)
								throw new ArgumentNullException(
									nameof(args),
									$"The {nameof(args).SQuote()} argument is null, and the argument type for this " +
									$"command type is {expectedArgumentType.FormatName().SQuote()}, which is a value " +
									$"type and not nullable.");

							if (!expectedArgumentType.IsInstanceOfType(args))
								throw new NotSupportedException(
									$"The {nameof(args).SQuote()} argument of type {args.GetType().FormatName().SQuote()} " +
									$"with value '{args}' is not valid. Expected argument to be of type " +
									$"{expectedArgumentType.FormatName().SQuote()}.");

							var methodInfo = type.GetMethod(nameof(TerminalCommand.Execute));
							//var genericMethodInfo = methodInfo?.MakeGenericMethod(args.GetType());

							if (methodInfo == null)
							{
								var argumentTypeName = args
									.GetType()
									.FormatName();

								throw new MissingMethodException(
									$"Cannot find generic method 'void {nameof(TerminalCommand.Execute)}" +
									$"<{argumentTypeName}>({argumentTypeName} args);'");
							}

							try
							{
								XConsole
									.Write($"Starting Command: ", Swatch.Cyan)
									.Write($"{CommandName.Quote()}", Swatch.Teal)
									.Write(" with args ", Swatch.Cyan)
									.WriteLine($"{args.ToString().SQuote()}", Swatch.Teal);

								methodInfo.Invoke(this, new[] { args });

								XConsole
									.WriteLine("command completed, with no errors.", Swatch.Green)
									.WriteLine();
							}
							catch (Exception ex)
							{
								WriteExceptionToConsole(ex);
							}
							break;
						}
				}
			}
		}

		private void WriteExceptionToConsole(
			Exception ex)
		{
			XConsole
				.AddUnderline()
				.SetBold()
				.WriteLine("  EXCEPTION THROWN  ", Swatch.Red)
				.RemoveUnderline()
				.SetNormalIntensity();

			XConsole
				.WriteLine(ex.ToString(), Swatch.Red)
				.WriteLine()
				.WriteLine();

			XConsole
				.WriteLine("command completed, with errors.", Swatch.Red)
				.WriteLine();
		}
	}
}
