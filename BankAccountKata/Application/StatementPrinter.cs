using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string Statement_Header = "Date || Amount || Balance";
        private readonly ITestableConsole console;

        public StatementPrinter(ITestableConsole console)
        {
            this.console = console;
        }

        public void Print(List<Transaction> allTransactions)
        {
            console.PrintLine(Statement_Header);
            PrintAllTransactions(allTransactions);
        }

        private void PrintAllTransactions(List<Transaction> allTransactions)
        {
            var balanceAmount = 0;
            var statementPrint = new List<string>();
            foreach (Transaction transaction in allTransactions)
            {
                balanceAmount += transaction.Amount;
                statementPrint.Add($"{transaction.Date} || {transaction.Amount} || {balanceAmount}");
            }
            if (statementPrint.Any())
            {
                for (int i = statementPrint.Count() - 1; i >= 0; i--)
                {
                    console.PrintLine(statementPrint[i]);
                }
            }
        }
    }
}