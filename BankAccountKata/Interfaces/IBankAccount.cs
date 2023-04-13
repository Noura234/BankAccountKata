using BankAccountKata.Application;

namespace BankAccountKata.Interfaces
{
    public interface IBankAccount
    {
        void PrintStatement();
        void Deposit(int amount);
        void WithDraw(int amount);
        List<Transaction> AllTransactions();
    }
}