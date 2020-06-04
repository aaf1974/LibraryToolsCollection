using ExtensionLibrary.EnumExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionLibraryTest.EnumExtTests
{
    public class IsSetTests
    {
        [Fact]
        public void CheckIfTrue()
        {
            SampleFlagEnum eVal = SampleFlagEnum.FirstFlag | SampleFlagEnum.SecondFlag;

            var res = eVal.LtcIsSet(SampleFlagEnum.SecondFlag);
            Assert.True(res);
        }

        [Fact]
        public void CheckIfFalse()
        {
            SampleFlagEnum eVal = SampleFlagEnum.FirstFlag | SampleFlagEnum.SecondFlag;

            var res = eVal.LtcIsSet(SampleFlagEnum.ThreedFlag);
            Assert.False(res);
        }

    }
}
