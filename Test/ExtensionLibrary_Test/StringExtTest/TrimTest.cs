using ExtensionLibrary.StringExt;
using Xunit;

namespace ExtensionLibraryTest.StringExtTest
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
