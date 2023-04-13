using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class Clock : IClock
    {
        public Clock()
        {
        }

        public string DateAsString()
        {
            return Today().ToString("yyyy-MM-dd");
        }

        protected virtual DateTime Today()
        {
            return DateTime.Now;
        }
    }
}