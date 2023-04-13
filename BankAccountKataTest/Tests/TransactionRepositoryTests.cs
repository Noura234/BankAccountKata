using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class TransactionRepositoryTests
    {
        private const string _today = "2012-01-14";
        private readonly TransactionRepository _transactionRepository;
        private readonly Mock<IClock> _clockMock;

        public TransactionRepositoryTests()
        {
            _clockMock = new Mock<IClock>();
            _transactionRepository = new TransactionRepository(_clockMock.Object);
        }
        [Fact]
        public void create_And_Store_Deposit_Transaction()
        {
            _clockMock.Setup(x => x.TodayAsString()).Returns(_today);
            _transactionRepository.AddDeposit(1000);
            IEnumerable<Transaction> transactions = _transactionRepository.AllTransactions();
            Assert.Single(transactions);
            Assert.Equal(_today, transactions.Single().Date);
            Assert.Equal(1000, transactions.Single().Amount);
        }

        [Fact]
        public void create_And_Store_WithDraw_Transaction()
        {
            _clockMock.Setup(x => x.TodayAsString()).Returns(_today);
            _transactionRepository.WithDraw(500);
            IEnumerable<Transaction> transactions = _transactionRepository.AllTransactions();
            Assert.Single(transactions);
            Assert.Equal(_today, transactions.Single().Date);
            Assert.Equal(-500, transactions.Single().Amount);
        }
    }
}
