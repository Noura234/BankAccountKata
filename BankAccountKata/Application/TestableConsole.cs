using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class TestableConsole : ITestableConsole
    {
        public void PrintLine(string valueToPrint)
        {
            Console.WriteLine( valueToPrint);
        }
    }
}