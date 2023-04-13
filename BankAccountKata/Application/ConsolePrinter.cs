using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class ConsolePrinter : IConsolePrinter
    {
        public void PrintLine(string valueToPrint)
        {
            Console.WriteLine( valueToPrint);
        }
    }
}