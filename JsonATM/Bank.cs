namespace JsonATM
{
    class Bank(List<Account> accounts, string currency)
    {
        public List<Account> Accounts { get; set; } = accounts;
        public string Currency { get; set; } = currency;
    }
}