using BankAccountKata.Interfaces;

namespace BankAccountKata
{
    internal class BankAccount
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _printStatement;

        internal BankAccount(ITransactionRepository transactionRepository, IStatementPrinter printStatement)
        {
            this._transactionRepository = transactionRepository;
            _printStatement = printStatement;
        }

        internal void deposit(int amount)
        {
           _transactionRepository.AddDeposit(amount);
        }

        internal void printStatement()
        {
            _printStatement.Print(_transactionRepository.AllTransactions());
        }

        internal void withdraw(int amount)
        {
           _transactionRepository.WithDraw(amount);
        }
    }
}