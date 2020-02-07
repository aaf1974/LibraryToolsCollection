using ExtensionLibrary.StringExt;
using Xunit;

namespace ExtensionLibraryTest.StringExtTest
{
    public class ToCamelCaseTests
    {
        [Fact]
        public void Convert_One_word()
        {
            string val = "one";
            var res = val.Ltc2CamelCase();


            Assert.Equal("One", res);
        }
        /*
                [Fact]
                public void Convert_some_word()
                {
                    string val = "one this day";
                    var res = val.Ltc2CamelCase();


                    Assert.Equal("One This Day", res);
                }*/
    }
}
