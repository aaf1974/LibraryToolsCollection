using ExtensionLibrary.StringExt;
using Xunit;

namespace ExtensionLibraryTest.StringExtTest
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
            Assert.True(value.LtcIsNumberOnly(hasPoin) == result);
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
            Assert.True(value.LtcIsNumberOnly() == result);
        }
    }
}
