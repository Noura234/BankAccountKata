using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class BankAccount
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _printStatement;

        public BankAccount(ITransactionRepository transactionRepository, IStatementPrinter printStatement)
        {
            _transactionRepository = transactionRepository;
            _printStatement = printStatement;
        }

        public void deposit(int amount)
        {
            _transactionRepository.AddDeposit(amount);
        }

        public void printStatement()
        {
            _printStatement.Print(_transactionRepository.AllTransactions());
        }

        public void withdraw(int amount)
        {
            _transactionRepository.WithDraw(amount);
        }
    }
}