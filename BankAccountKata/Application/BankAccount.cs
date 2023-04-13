using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class BankAccount : IBankAccount
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IStatementPrinter _printStatement;

        public BankAccount(ITransactionRepository transactionRepository, IStatementPrinter printStatement)
        {
            _transactionRepository = transactionRepository;
            _printStatement = printStatement;
        }

        public void Deposit(int amount)
        {
            _transactionRepository.AddDeposit(Math.Abs(amount));
        }

        public List<Transaction> AllTransactions()
        {
            return  _transactionRepository.AllTransactions();
        }
        public void PrintStatement()
        {
            _printStatement.Print(_transactionRepository.AllTransactions());
        }

        public void WithDraw(int amount)
        {
            _transactionRepository.WithDraw(Math.Abs(amount));
        }
    }
}