using BankAccountKata.Application;
using BankAccountKata.Interfaces;
using Moq;

namespace BankAccountKata.Tests
{
    public class StatementPrinterTests
    {
        private readonly StatementPrinter printer;
        private readonly Mock<ITestableConsole> mockConsole;
        public StatementPrinterTests()
        {
            mockConsole = new Mock<ITestableConsole>();
            printer = new StatementPrinter(mockConsole.Object);
        }

        [Fact]
        public void always_print_header()
        {
            List<Transaction> transactions = new List<Transaction>();
            printer.Print(transactions);

            mockConsole.Verify(x => x.PrintLine("Date || Amount || Balance"), Times.Once);
        }

        [Fact]
        public void print_transaction_in_order()
        {
            List<Transaction> transactions = new List<Transaction>() { 
                new Transaction("2012-01-10", 1000) { },
                new Transaction("2012-01-13", 2000) { },
                new Transaction("2012-01-14", -500) { }
            };
            printer.Print(transactions);

            mockConsole.Verify(x => x.PrintLine("Date || Amount || Balance"), Times.Once);
            mockConsole.Verify(cm => cm.PrintLine("2012-01-14 || -500 || 2500"), Times.Once);
            mockConsole.Verify(cm => cm.PrintLine("2012-01-13 || 2000 || 3000"), Times.Once);
            mockConsole.Verify(cm => cm.PrintLine("2012-01-10 || 1000 || 1000"), Times.Once);
        }
    }
}
