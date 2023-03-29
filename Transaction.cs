namespace BankAccountKata
{
    public class Transaction
    {
        private string date;
        private int amount;

        public Transaction(string date, int amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public override bool Equals(object? obj)
        {
            if(this == obj) return true;
            if(obj == null || this.GetType() !=  obj.GetType()) return false;
            Transaction that = (Transaction) obj;
            if(!that.amount.Equals(amount)) return false;
            if(date != null ? !date.Equals(that.date) : that.date !=null) return false;
            return true;
        }

        public int Amount()
        {
            return amount;
        }
        public string Date()
        {
            return date;
        }
    }
}