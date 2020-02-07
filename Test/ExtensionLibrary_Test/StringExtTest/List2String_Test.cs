using ExtensionLibrary.StringExt;
using System.Collections.Generic;
using Xunit;

namespace ExtensionLibraryTest.StringExtTest
{
    public class List2String_Test
    {
        private List<string> _lst = new List<string>() { "one", "two", "three" };

        [Fact]
        public void Convert_List()
        {
            var res = _lst.LtcList2String();

            Assert.Equal(string.Join(", ", _lst), res);
        }

        [Fact]
        public void Convert_Array()
        {
            var res = _lst.ToArray().LtcList2String();

            Assert.Equal(string.Join(", ", _lst), res);
        }

        [Fact]
        public void Convert_OtherSeparator()
        {
            var res = _lst.LtcList2String(";");

            Assert.Equal(string.Join("; ", _lst), res);
        }
    }
}
