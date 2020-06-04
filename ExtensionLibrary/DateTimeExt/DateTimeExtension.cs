using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionLibrary.DateTimeExt
{
    public static class DateTimeExtension
    {

        //https://extensionmethod.net/csharp/datetime/daterange
        public static IEnumerable<DateTime> LtcGetDateRangeTo(this DateTime self, DateTime toDate)
        {
            var range = Enumerable.Range(0, new TimeSpan(toDate.Ticks - self.Ticks).Days);

            return from p in range
                   select self.Date.AddDays(p);
        }

        public static bool LtcIsWeekend(this DateTime value)
        {
            return (value.DayOfWeek == DayOfWeek.Sunday || value.DayOfWeek == DayOfWeek.Saturday);
        }
    }
}
