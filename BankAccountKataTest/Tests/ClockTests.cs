using BankAccountKata.Application;

namespace BankAccountKata.Tests
{
    public  class ClockTests
    {
        private const string _today = "2012-01-10";

        [Fact]
        public void return_Date_In_Dd_Mm_Yy_Format()
        {
            var clock = new TestableClock();
            var today = clock.TodayAsString();
            Assert.Equal(_today, today);

        }

        private class TestableClock : Clock
        {
            protected override DateTime Today()
            {
                return new DateTime(2012,1, 10);
            }
        }
    }
}
