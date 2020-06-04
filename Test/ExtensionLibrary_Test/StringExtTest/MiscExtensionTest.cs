using ExtensionLibrary.StringExt;
using Xunit;

namespace ExtensionLibraryTest.StringExtTest
{
    public class MiscExtensionTest
    {
        [Fact]
        public void InTest()
        {
            string[] sCollection = new string[] { "one", "two", "yes" };

            var res = "yes".LtcIn(sCollection);
            Assert.True(res);

            res = "NO".LtcIn(sCollection);
            Assert.False(res);
        }


        [Fact]
        public void UpperFirst()
        {
            string val = "hello";

            string res = val.LtcUpperFirst();
            Assert.Equal("Hello", res);

            val = null;
            res = val.LtcUpperFirst();
            Assert.Null(res);
        }

        [Fact]
        public void IsDate()
        {
            var res = "Foo".LtcIsDate();
            Assert.False(res);

            res = "Jan 1 2010".LtcIsDate();
            Assert.True(res);
        }



        [Fact]
        public void IsEmail()
        {
            var res = "aaa@ru".LtcIsEmailAddress();
            Assert.False(res);

            res = "aaa@ru.ru".LtcIsEmailAddress();
            Assert.True(res);

            res = "aa.aaa@aa.ru.ru".LtcIsEmailAddress();
            Assert.True(res);
        }
    }
}
