namespace JsonATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currency = "kr";

            var accounts = PopulatedAccounts();

            Bank bank = new(accounts, currency);

            ATM ATM = new(bank);

            ATM.Run();
        }
        private static List<Account> PopulatedAccounts()
        {
            List<Account> accounts = [];

            for ( int i = 0; i < 10; i++)
            {
                string str = $"{i}{i}{i}";
                accounts.Add(new Account($"{str}-{str}"));
                accounts[i].Deposit(i * 1000);
            }

            return accounts;
        }
    }
}
