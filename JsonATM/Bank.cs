namespace JsonATM
{
    class Bank(List<Account> accounts, string currency)
    {
        private List<Account> Accounts { get; set; } = accounts;
        public string Currency { get; set; } = currency;

        public void Deposit(string accountNumber, double amount)
        {
            CheckNegativeAmount(amount);

            Account account = GetAccount(accountNumber);

            account.Balance += amount;
        }
        public void Withdraw(string accountNumber, double amount)
        {
            CheckNegativeAmount(amount);

            Account account = GetAccount(accountNumber);

            if (account.Balance < amount) { throw new ArgumentException("Invalid amount"); }

            account.Balance -= amount;
        }
        public List<Account> GetAccounts()
        {
            return [.. Accounts]; // Return a copy of the list for security
        }
        public double GetBalance(string accountNumber)
        {
            return GetAccount(accountNumber).Balance;
        }
        private Account GetAccount(string accountNumber)
        {
            return Accounts.FirstOrDefault(account => account.AccountNumber == accountNumber)
                ?? throw new KeyNotFoundException("Account not found");
        }
        private static void CheckNegativeAmount(double amount)
        {
            if (amount < 0.0) { throw new ArgumentException("Invalid amount"); }
        }
    }
}