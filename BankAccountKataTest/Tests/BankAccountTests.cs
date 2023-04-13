using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class BankAccountTests
    {
        private readonly Mock<ITransactionRepository> _transactionRepository;
        private readonly BankAccount _account;
        private readonly Mock<IStatementPrinter> _printStatement;

        public BankAccountTests()
        {
            _transactionRepository = new Mock<ITransactionRepository>();
            _printStatement = new Mock<IStatementPrinter>();
            _account = new BankAccount(_transactionRepository.Object, _printStatement.Object);
        }
        [Fact]
        public void store_Deposit_Transaction()
        {
            _account.Deposit(1000);
            _transactionRepository.Verify(tr => tr.AddDeposit(1000), Times.Once);
        }

        [Fact]
        public void store_Withdraw_Transaction()
        {
            _account.WithDraw(1000);
            _transactionRepository.Verify(tr => tr.WithDraw(1000), Times.Once);
        }

        [Fact]
        public void print_Statement()
        {
            var allTransactions = new List<Transaction>() { new Transaction("2012-01-10", 1000) };
            _transactionRepository.Setup(x => x.AllTransactions()).Returns(allTransactions);
            _account.PrintStatement();
            _printStatement.Verify(ps => ps.Print(allTransactions), Times.Once);
        }
    }
}
