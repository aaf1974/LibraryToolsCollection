using ExtensionLibrary.StringExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionLibrary_Test.StringExt_Test
{
    public class IsNumberOnly_Test
    {
        [Theory]
        [InlineData("12345", false, true)]
        [InlineData("   12345", false, true)]
        [InlineData("12.345", true, true)]
        [InlineData("   12,345 ", true, true)]
        [InlineData("12 345", false, false)]
        [InlineData("tractor", true, false)]
        public void IsNumberOnly(string value, bool hasPoin, bool result)
        {
            Assert.True(value.IsNumberOnly(hasPoin) == result);
        }


        [Theory]
        [InlineData("12345", true)]
        [InlineData("   12345", true)]
        [InlineData("12.345", true)]
        [InlineData("   12,345 ", true)]
        [InlineData("12 345", false)]
        [InlineData("tractor", false)]
        public void IsNumberOnlyTest(string value, bool result)
        {
            Assert.True(value.IsNumberOnly() == result);
        }
    }
}
