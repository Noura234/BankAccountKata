using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    internal class TestableConsole : ITestableConsole
    {
        public void printLine(string v)
        {
            throw new NotImplementedException();
        }
    }
}