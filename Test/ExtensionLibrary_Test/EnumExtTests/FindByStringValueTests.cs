using ExtensionLibrary.EnumExt;
using System;
using Xunit;


namespace ExtensionLibraryTest.EnumExtTests
{
    public class FindByStringValueTests
    {
        [Fact]
        public void FindCorrectName()
        {
            var sVal = SampleEnum.One.ToString();
            SampleEnum se = Enum<SampleEnum>.FindByString(sVal);

            Assert.Equal(sVal, se.ToString());
        }


        [Fact]
        public void FindNotCorrectName()
        {
            string sVal = "badSymbol";

            Assert.Throws<ArgumentException>(() => Enum<SampleEnum>.FindByString(sVal));
        }


        [Fact]
        public void FindNotCorrectNameWithDefault()
        {
            string sVal = "badSymbol";

            SampleEnum se = Enum<SampleEnum>.FindByString(sVal, SampleEnum.Two);

            Assert.Equal(SampleEnum.Two, se);
        }
    }
}
