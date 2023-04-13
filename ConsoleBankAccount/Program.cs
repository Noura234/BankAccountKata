using BankAccountKata.Application;

namespace ConsoleBankAccount
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var clock = new Clock();
            var transactionRepository = new TransactionRepository(clock);
            var console = new ConsolePrinter();
            var printStatement = new StatementPrinter(console);
            var bankAccount = new BankAccount(transactionRepository, printStatement);
            bankAccount.Deposit(1000);
            bankAccount.Deposit(2000);
            bankAccount.WithDraw(500);
            bankAccount.PrintStatement();
        }
    }
}