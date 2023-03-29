using BankAccountKata.Interfaces;

namespace BankAccountKata
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