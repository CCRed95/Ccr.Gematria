namespace Ccr.Gematria.Terminal
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var terminalApplication = new GematriaTerminalApplication(args);
			terminalApplication.Start();
		}
	}
}
