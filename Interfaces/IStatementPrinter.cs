using BankAccountKata.Application;

namespace BankAccountKata.Interfaces
{
    public interface IStatementPrinter
    {
        void Print(List<Transaction> allTransactions);
    }
}