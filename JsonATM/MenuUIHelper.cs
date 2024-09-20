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
        public static double UserInputAmount()
        {
            Console.Write(ClearConsole +
                "Enter amount\n" +
                ": ");

            try {
                return double.Parse(Console.ReadLine() ?? "");
            }
            catch (FormatException ex) {
                throw new ArgumentException("Invalid amount\n" +
                                            "Amount must be a number", ex);
            }
        }
        public static void WaitUserInput()
        {
            Console.Write("Press enter to continue");
            Console.ReadLine();
        }
        public static void ErrorMessage(Exception exception)
        {
            Console.WriteLine(ClearConsole +
                exception.Message);
        }
    }
}
