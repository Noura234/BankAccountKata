using BankAccountKata.Application;

namespace BankAccountKata.Interfaces
{
    public interface ITransactionRepository
    {
        void AddDeposit(int v);
        List<Transaction> AllTransactions();
        void WithDraw(int v);
    }
}