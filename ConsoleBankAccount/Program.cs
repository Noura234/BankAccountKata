using BankAccountKata.Application;

namespace ConsoleBankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var clock = new Clock();
            var transactionRepository = new TransactionRepository(clock);
            var consoleMock = new TestableConsole();
            var printStatement = new StatementPrinter(consoleMock);
            var bankAccount = new BankAccount(transactionRepository, printStatement);
            bankAccount.deposit(1000);
            bankAccount.deposit(2000);
            bankAccount.withdraw(500);
            bankAccount.printStatement();
        }
    }
}