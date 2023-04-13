using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class StatementPrinterTests
    {
        private readonly StatementPrinter _statementPrinter;
        private readonly Mock<IConsolePrinter> _mockConsole;
        public StatementPrinterTests()
        {
            _mockConsole = new Mock<IConsolePrinter>();
            _statementPrinter = new StatementPrinter(_mockConsole.Object);
        }

        [Fact]
        public void always_Print_Header()
        {
            List<Transaction> transactions = new List<Transaction>();
            _statementPrinter.Print(transactions);

            _mockConsole.Verify(x => x.PrintLine("Date || Amount || Balance"), Times.Once);
        }

        [Fact]
        public void print_Transaction_In_Order()
        {
            List<Transaction> transactions = new List<Transaction>() { 
                new Transaction("2012-01-10", 1000) { },
                new Transaction("2012-01-13", 2000) { },
                new Transaction("2012-01-14", -500) { }
            };
            _statementPrinter.Print(transactions);

            _mockConsole.Verify(x => x.PrintLine("Date || Amount || Balance"), Times.Once);
            _mockConsole.Verify(cm => cm.PrintLine("2012-01-14 || -500 || 2500"), Times.Once);
            _mockConsole.Verify(cm => cm.PrintLine("2012-01-13 || 2000 || 3000"), Times.Once);
            _mockConsole.Verify(cm => cm.PrintLine("2012-01-10 || 1000 || 1000"), Times.Once);
        }
    }
}
