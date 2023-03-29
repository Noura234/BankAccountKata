using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class PrintStatementAcceptanceTests
    {
        [Fact]
        public void Print_Statement_Contains_All_Transactions()
        {
            var mockClock = new Mock<IClock>();            
            var transactionRepository = new TransactionRepository(mockClock.Object);
            var consoleMock = new Mock<ITestableConsole>();
            var printStatement = new StatementPrinter(consoleMock.Object);
            var bankAccount = new BankAccount(transactionRepository, printStatement);
            mockClock.Setup(x => x.DateAsString()).Returns("2012-01-10");
            bankAccount.deposit(1000);
            mockClock.Setup(x => x.DateAsString()).Returns("2012-01-13");
            bankAccount.deposit(2000);
            mockClock.Setup(x => x.DateAsString()).Returns("2012-01-14");
            bankAccount.withdraw(500);
            bankAccount.printStatement();
            consoleMock.Verify(cm => cm.printLine("Date || Amount || Balance"), Times.Once);
            consoleMock.Verify(cm => cm.printLine("2012-01-14 || -500 || 2500"), Times.Once);
            consoleMock.Verify(cm => cm.printLine("2012-01-13 || 2000 || 3000"), Times.Once);
            consoleMock.Verify(cm => cm.printLine("2012-01-10 || 1000 || 1000"), Times.Once);

        }
    }
}