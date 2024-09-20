using System.Text.Json;

namespace JsonATM
{
    class Bank(string currency, string dataFilePath) : IDisposable
    {
        private List<Account> Accounts { get; set; } = GetAccountData(dataFilePath);
        public string Currency { get; set; } = currency;
        public string DataFilePath { get; set; } = dataFilePath;

        private static List<Account> GetAccountData(string dataFilePath)
        {
            string jsonData = File.ReadAllText(dataFilePath);

            return JsonSerializer.Deserialize<List<Account>>(jsonData) ?? [];
        }
        public void Dispose() { SaveAccountData(); }
        public void SaveAccountData()
        {
            string jsonData = JsonSerializer.Serialize(Accounts);
            File.WriteAllText(DataFilePath, jsonData);
        }

        public void Deposit(string accountNumber, double amount)
        {
            CheckNegativeAmount(amount);

            Account account = GetAccount(accountNumber);

            if (double.IsInfinity(account.Balance + amount)) { throw new ArgumentException("Invalid amount"); }

            account.Balance += amount;
        }
        public void Withdraw(string accountNumber, double amount)
        {
            CheckNegativeAmount(amount);

            Account account = GetAccount(accountNumber);

            if (account.Balance < amount) { throw new ArgumentException("Invalid amount"); }

            account.Balance -= amount;
        }
        public void NewAccount(string accountNumber)
        {
            Accounts.Add(new Account(accountNumber));
        }
        public void DeleteAccount(string accountNumber)
        {
            Accounts.Remove(GetAccount(accountNumber));
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