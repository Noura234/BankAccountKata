using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class BankAccountTests
    {
        private readonly Mock<ITransactionRepository> transactionRepository;
        private readonly BankAccount account;
        private readonly Mock<IStatementPrinter> printStatement;

        public BankAccountTests()
        {
            transactionRepository = new Mock<ITransactionRepository>();
            printStatement = new Mock<IStatementPrinter>();
            account = new BankAccount(transactionRepository.Object, printStatement.Object);
        }
        [Fact]
        public void store_deposit_transation()
        {
            account.deposit(1000);
            transactionRepository.Verify(tr => tr.AddDeposit(1000), Times.Once);
        }

        [Fact]
        public void store_withdraw_transation()
        {
            account.withdraw(1000);
            transactionRepository.Verify(tr => tr.WithDraw(1000), Times.Once);
        }

        [Fact]
        public void print_statement()
        {
            var allTransactions = new List<Transaction>() { new Transaction("2012-01-10", 1000) };
            transactionRepository.Setup(x => x.AllTransactions()).Returns(allTransactions);
            account.printStatement();
            printStatement.Verify(ps => ps.Print(allTransactions), Times.Once);
        }
    }
}
