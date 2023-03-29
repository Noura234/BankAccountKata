using BankAccountKata.Interfaces;

namespace BankAccountKata
{
    internal class TestableConsole : ITestableConsole
    {
        public void printLine(string v)
        {
            throw new NotImplementedException();
        }
    }
}