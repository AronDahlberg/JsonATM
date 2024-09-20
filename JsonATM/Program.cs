namespace JsonATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string currency = "kr";

            string bankDataFilePath = "BankData.json";

            using Bank bank = new(currency, bankDataFilePath);

            ATM ATM = new(bank);

            ATM.Run();
        }
    }
}
