using ExtensionLibrary.StringExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionLibrary_Test.StringExt_Test
{
    public class TrimTest
    {
        [Theory]
        [InlineData("Norm", "Norm")]
        [InlineData("  Before", "Before")]
        [InlineData("After ", "After")]
        [InlineData("  Кругом ", "Кругом")]
        [InlineData(null, "")]
        public void TestTrim(string value, string result)
        {
            string extRes = value.LtcTrim();

            Assert.Equal(result, extRes);
        }
    }
}
