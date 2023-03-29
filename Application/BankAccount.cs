using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    internal class BankAccount
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _printStatement;

        internal BankAccount(ITransactionRepository transactionRepository, IStatementPrinter printStatement)
        {
            _transactionRepository = transactionRepository;
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