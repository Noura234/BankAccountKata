using BankAccountKata.Interfaces;

namespace BankAccountKata.Application
{
    public class Clock : IClock
    {
        public Clock()
        {
        }

        public string TodayAsString()
        {
            return Today().ToString("yyyy-MM-dd");
        }

        protected virtual DateTime Today()
        {
            return DateTime.Now;
        }
    }
}