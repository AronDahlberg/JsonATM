using static JsonATM.MenuUIHelper;

namespace JsonATM
{
    internal class ATM(Bank bank)
    {
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
                        "4: Add account\n" +
                        "5: Remove account\n" +
                        "6: Exit\n");

                input = Console.ReadLine();

                switch (input)
                {
                    case "0": Deposit(); break;

                    case "1": Withdraw(); break;

                    case "2": PrintBalance(); break;

                    case "3": PrintAccounts(); break;

                    case "4": AddAccount(); break;

                    case "5": RemoveAccount(); break;

                    case "6": IsRunning = false; break;
                }
            }

            Console.Write(ClearConsole);
        }
        private void Deposit()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();
                double amount = UserInputAmount();

                Bank.Deposit(accountNumber, amount);

                Console.WriteLine(ClearConsole +
                    "Deposit succesfull");
            }
            catch (Exception ex) { ErrorMessage(ex); }
            WaitUserInput();
        }
        private void Withdraw()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();
                double amount = UserInputAmount();

                Bank.Withdraw(accountNumber, amount);

                Console.WriteLine(ClearConsole +
                    "Withdrawal succesfull");
            }
            catch (Exception ex) { ErrorMessage(ex); }
            WaitUserInput();
        }
        private void PrintBalance()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();
                double balance = Bank.GetBalance(accountNumber);

                Console.WriteLine(ClearConsole +
                    $"Balance for account {accountNumber}\n" +
                    $": {balance}{Bank.Currency}");
            }
            catch (Exception ex) { ErrorMessage(ex); }
            WaitUserInput();
        }
        private void PrintAccounts()
        {
            try
            {
                Console.Write(ClearConsole);

                var accounts = Bank.GetAccounts();

                for (int i = 0; i < accounts.Count; i++)
                {
                    Console.WriteLine(accounts[i].ToString() + Bank.Currency);
                }
            }
            catch (Exception ex) { ErrorMessage(ex); }
            WaitUserInput();
        }
        private void AddAccount()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();

                Bank.NewAccount(accountNumber);

                Console.WriteLine(ClearConsole +
                    $"New account {accountNumber} created");
            }
            catch (Exception ex) { ErrorMessage(ex); }
            WaitUserInput();
        }
        private void RemoveAccount()
        {
            try
            {
                string accountNumber = UserInputAccountNumber();

                Bank.DeleteAccount(accountNumber);

                Console.WriteLine(ClearConsole +
                    $"Account {accountNumber} removed");
            }
            catch (Exception ex) { ErrorMessage(ex); }
            WaitUserInput();
        }
    }
}
