using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class TestableConsole : ITestableConsole
    {
        public void printLine(string valueToPrint)
        {
            Console.WriteLine( valueToPrint);
        }
    }
}