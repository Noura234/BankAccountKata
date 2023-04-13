namespace BankAccountKata.Application
{
    public class Transaction
    {
        public Transaction(string date, int amount)
        {
            Amount = amount;
            Date = date;
        }

        public int Amount { get; private set; }
        
        public string Date { get; private set; }

    }
}