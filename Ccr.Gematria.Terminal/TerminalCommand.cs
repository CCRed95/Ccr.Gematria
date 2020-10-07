namespace Ccr.Gematria.Terminal
{
	public abstract class TerminalCommand
		: TerminalCommandBase
	{
		public abstract void Execute();
	}

	public abstract class TerminalCommand<TCommandArgs>
		: TerminalCommandBase
	{
		public abstract void Execute(TCommandArgs args);
	}
}