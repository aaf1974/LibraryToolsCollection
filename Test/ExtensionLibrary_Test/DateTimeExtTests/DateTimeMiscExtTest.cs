using ExtensionLibrary.DateTimeExt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ExtensionLibraryTest.DateTimeExtTests
{
    public class DateTimeMiscExtTest
    {
        [Fact]
        public void CreateDateRange()
        {
            DateTime sDate = DateTime.Now;
            IEnumerable<DateTime> dateRange = sDate.LtcGetDateRangeTo(DateTime.Now.AddDays(3));

            Assert.Equal(3, dateRange.Count());
            Assert.Contains(sDate.Date, dateRange);
            Assert.Contains(sDate.AddDays(1).Date, dateRange);
            Assert.Contains(sDate.AddDays(2).Date, dateRange);
        }

        [Fact]
        public void IsWeekend()
        {
            Assert.True(new DateTime(2020, 6, 6).LtcIsWeekend());
            Assert.True(new DateTime(2020, 6, 7).LtcIsWeekend());
            Assert.False(new DateTime(2020, 6, 8).LtcIsWeekend());
        }
    }
}
