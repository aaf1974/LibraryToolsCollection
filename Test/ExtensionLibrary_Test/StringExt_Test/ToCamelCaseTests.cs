using ExtensionLibrary.StringExt;
using Xunit;

namespace ExtensionLibrary_Test.StringExt_Test
{
    public class ToCamelCaseTests
    {
        [Fact]
        public void Convert_List()
        {
            string val = "one";
            var res = val.Ltc2CamelCase();


            Assert.Equal("One1", res);
        }
    }
}
