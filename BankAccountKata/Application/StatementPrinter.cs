using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class StatementPrinter : IStatementPrinter
    {
        private const string _statementHeader = "Date || Amount || Balance";
        private readonly IConsolePrinter _console;

        public StatementPrinter(IConsolePrinter console)
        {
            this._console = console;
        }

        public void Print(List<Transaction> allTransactions)
        {
            _console.PrintLine(_statementHeader);
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
                    _console.PrintLine(statementPrint[i]);
                }
            }
        }
    }
}