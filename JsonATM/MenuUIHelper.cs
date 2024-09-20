namespace JsonATM
{
    internal static class MenuUIHelper
    {
        public static string ClearConsole { get; } = "\x1b[2J\x1b[H"; // ANSI ESC Code

        public static string UserInputAccountNumber()
        {
            Console.Write(ClearConsole +
                "Enter account number\n" +
                ": ");

            return Console.ReadLine() ?? "";
        }
        public static string UserInputAmount()
        {
            Console.Write(ClearConsole +
                "Enter amount\n" +
                ": ");

            return Console.ReadLine() ?? "";
        }
        public static void WaitUserInput()
        {
            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        public static void ErrorMessage(Exception exception)
        {
            Console.WriteLine(ClearConsole +
                exception.Message);
        }
        public static void UnkownErrorMessage(Exception exception)
        {
            Console.WriteLine(ClearConsole +
                "An unkown error has occured:\n" +
                exception.Message);
        }
    }
}
