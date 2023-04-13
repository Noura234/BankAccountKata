using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class TransactionRepositoryTests
    {
        private const string TODAY = "2012-01-14";
        private readonly TransactionRepository repository;
        private readonly Mock<IClock> clockMock;

        public TransactionRepositoryTests()
        {
            clockMock = new Mock<IClock>();
            repository = new TransactionRepository(clockMock.Object);
        }
        [Fact]
        public void create_and_store_deposit_transaction()
        {
            clockMock.Setup(x => x.DateAsString()).Returns(TODAY);
            repository.AddDeposit(1000);
            IEnumerable<Transaction> transactions = repository.AllTransactions();
            Assert.Single(transactions);
            Assert.Equal(TODAY, transactions.Single().Date);
            Assert.Equal(1000, transactions.Single().Amount);
        }

        [Fact]
        public void create_and_store_withdraw_transaction()
        {
            clockMock.Setup(x => x.DateAsString()).Returns(TODAY);
            repository.WithDraw(500);
            IEnumerable<Transaction> transactions = repository.AllTransactions();
            Assert.Single(transactions);
            Assert.Equal(TODAY, transactions.Single().Date);
            Assert.Equal(-500, transactions.Single().Amount);
        }
    }
}
