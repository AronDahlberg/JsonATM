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
                var account = GetAccount() ?? throw new NullReferenceException();

                double amount = double.Parse(GetAmount());

                account.Deposit(amount);

                Console.WriteLine(ClearConsole +
                    "Deposit succesfull");
            }
            catch (Exception)
            {
                Console.WriteLine(ClearConsole +
                    "Deposit unsuccesfull");
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        public void Withdraw()
        {
            try
            {
                var account = GetAccount() ?? throw new NullReferenceException();

                double amount = double.Parse(GetAmount());

                if (amount > account.Balance)
                {
                    throw new ArgumentException("Invalid Amount");
                }

                account.Withdraw(amount);

                Console.WriteLine(ClearConsole +
                    "Withdrawal succesfull");
            }
            catch (Exception)
            {
                Console.WriteLine(ClearConsole +
                    "Withdrawal unsuccesfull");
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        public void PrintBalance()
        {
            try
            {
                var account = GetAccount() ?? throw new NullReferenceException();

                Console.WriteLine(ClearConsole +
                    $"Balance for account {account.AccountNumber}\n" +
                    $": {account.Balance}{Bank.Currency}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine(ClearConsole +
                    "Could not find account");
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        public void PrintAccounts()
        {
            Console.Write(ClearConsole);

            for (int i = 0; i < Bank.Accounts.Count; i++)
            {
                Console.WriteLine(Bank.Accounts[i].ToString() + Bank.Currency);
            }

            Console.Write("Press enter to return");
            Console.ReadLine();
        }
        private Account? GetAccount()
        {
            string? accountNmr = GetAccountNumber();

            return Bank.Accounts.FirstOrDefault(account => account.AccountNumber == accountNmr);
        }
        private string GetAccountNumber()
        {
            Console.Write(ClearConsole +
                "Enter account number\n" +
                ": ");

            return Console.ReadLine() ?? "";
        }
        private string GetAmount()
        {
            Console.Write(ClearConsole +
                "Enter amount\n" +
                ": ");

            return Console.ReadLine() ?? "";
        }
    }
}
