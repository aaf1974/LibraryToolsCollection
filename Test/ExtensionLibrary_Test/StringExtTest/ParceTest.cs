using ExtensionLibrary.StringExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionLibraryTest.StringExtTest
{
    public class ParceTest
    {
        [Fact]
        public void Parce()
        {
            Assert.Equal(123, "123".LtcParse<int>());
            Assert.Equal(123, "123".LtcParse<int?>());
            Assert.Equal(new DateTime(2008, 12, 1), "01/12/2008".LtcParse<DateTime>());
            Assert.Equal(new DateTime(2008, 12, 1), "01/12/2008".LtcParse<DateTime?>());


            string sample = null;
            Assert.Null( sample.LtcParse<int?>()); // returns null
            Assert.Equal(0, sample.LtcParse<int>());   // returns 0
            Assert.Equal(new DateTime(1,1,1), sample.LtcParse<DateTime>()); // returns 01/01/0001
            Assert.Null(sample.LtcParse<DateTime?>()); // returns null
        }
    }
}
