using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class TransactionRepository : ITransactionRepository
    {
        private IClock _clock;
        private List<Transaction> _transactions = new();

        public TransactionRepository(IClock clock)
        {
            this._clock = clock;
        }

        public List<Transaction> AllTransactions()
        {
            return _transactions;
        }

        public void WithDraw(int amount)
        {
            var transactionWithDraw = new Transaction(_clock.TodayAsString(), -amount);
            _transactions.Add(transactionWithDraw);
        }

        public void AddDeposit(int amount)
        {
            var transactionDeposit = new Transaction(_clock.TodayAsString(), amount);
            _transactions.Add(transactionDeposit);
        }
    }
}