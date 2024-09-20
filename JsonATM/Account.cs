namespace JsonATM
{
    internal class Account(string accountNumber)
    {
		private double _balance;

		public double Balance
		{
			get { return _balance; }
			set { _balance = value >= 0.0
					? value
					: _balance; }
		}
        public string AccountNumber { get; } = accountNumber;

		public override string ToString()
		{
			return $"{AccountNumber}: {Balance}";
		}
    }
}
