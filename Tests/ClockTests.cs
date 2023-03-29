namespace BankAccountKata.Tests
{
    public  class ClockTests
    {
        private const string TODAY = "2012-01-10";

        [Fact]
        public void return_date_in_dd_mm_yy_format()
        {
            var clock = new TestableClock();
            var today = clock.DateAsString();
            Assert.Equal(TODAY, today);

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
