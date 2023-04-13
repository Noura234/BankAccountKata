using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class PrintStatementAcceptanceTests
    {
        [Fact]
        public void print_Statement_Contains_All_Transactions()
        {
            var mockClock = new Mock<IClock>();            
            var transactionRepository = new TransactionRepository(mockClock.Object);
            var consoleMock = new Mock<IConsolePrinter>();
            var printStatement = new StatementPrinter(consoleMock.Object);
            var bankAccount = new BankAccount(transactionRepository, printStatement);
            mockClock.Setup(x => x.TodayAsString()).Returns("2012-01-10");
            bankAccount.Deposit(1000);
            mockClock.Setup(x => x.TodayAsString()).Returns("2012-01-13");
            bankAccount.Deposit(2000);
            mockClock.Setup(x => x.TodayAsString()).Returns("2012-01-14");
            bankAccount.WithDraw(500);
            bankAccount.PrintStatement();
            consoleMock.Verify(cm => cm.PrintLine("Date || Amount || Balance"), Times.Once);
            consoleMock.Verify(cm => cm.PrintLine("2012-01-14 || -500 || 2500"), Times.Once);
            consoleMock.Verify(cm => cm.PrintLine("2012-01-13 || 2000 || 3000"), Times.Once);
            consoleMock.Verify(cm => cm.PrintLine("2012-01-10 || 1000 || 1000"), Times.Once);
        }
    }
}