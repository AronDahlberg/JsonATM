namespace JsonATM
{
    internal class ATM(Bank bank)
    {
        private static string ClearConsole { get; } = "\x1b[2J\x1b[H"; // ANSI ESC Code
        private bool IsRunning { get; set; } = true;
        private Bank Bank { get; set; } = bank;

        public void Run()
        {
            string? input;

            while (IsRunning)
            {
                Console.Write(ClearConsole +
                        "0: Make a deposit\n" +
                        "1: Make a withdrawal\n" +
                        "2: See balance\n" +
                        "3: See all accounts\n" +
                        "4: Exit\n");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0": Deposit(); break;

                    case "1": Withdraw(); break;

                    case "2": PrintBalance(); break;

                    case "3": PrintAccounts(); break;

                    case "4": IsRunning = false; break;
                }
            }

            Console.Write(ClearConsole);
        }
        public void Deposit()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();
                double amount = double.Parse(UserInputAmount());

                Bank.Deposit(accountNumber, amount);

                Console.WriteLine(ClearConsole +
                    "Deposit succesfull");
            }
            catch (Exception)
            {
                Console.WriteLine(ClearConsole +
                    "Deposit unsuccesfull");
            }

            WaitUserInput();
        }
        public void Withdraw()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();
                double amount = double.Parse(UserInputAmount());

                Bank.Withdraw(accountNumber, amount);

                Console.WriteLine(ClearConsole +
                    "Withdrawal succesfull");
            }
            catch (Exception)
            {
                Console.WriteLine(ClearConsole +
                    "Withdrawal unsuccesfull");
            }

            WaitUserInput();
        }
        public void PrintBalance()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();
                double balance = Bank.GetBalance(accountNumber);

                Console.WriteLine(ClearConsole +
                    $"Balance for account {accountNumber}\n" +
                    $": {balance}{Bank.Currency}");
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine(ClearConsole +
                    "Could not find account");
            }

            WaitUserInput();
        }
        public void PrintAccounts()
        {
            Console.Write(ClearConsole);

            var accounts = Bank.GetAccounts();

            for (int i = 0; i < accounts.Count; i++)
            {
                Console.WriteLine(accounts[i].ToString() + Bank.Currency);
            }

            WaitUserInput();
        }
        private static string UserInputAccountNumber()
        {
            Console.Write(ClearConsole +
                "Enter account number\n" +
                ": ");

            return Console.ReadLine() ?? "";
        }
        private static string UserInputAmount()
        {
            Console.Write(ClearConsole +
                "Enter amount\n" +
                ": ");

            return Console.ReadLine() ?? "";
        }
        private static void WaitUserInput()
        {
            Console.Write("Press enter to return");
            Console.ReadLine();
        }
    }
}
