namespace BankAccountKata.Interfaces
{
    internal interface IStatementPrinter
    {
        void Print(List<Transaction> allTransactions);
    }
}