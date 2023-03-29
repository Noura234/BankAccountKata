namespace BankAccountKata.Interfaces
{
    internal interface ITransactionRepository
    {
        void AddDeposit(int v);
        List<Transaction> AllTransactions();
        void WithDraw(int v);
    }
}