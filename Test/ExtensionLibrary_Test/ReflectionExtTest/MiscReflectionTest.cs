using ExtensionLibrary.ReflectionExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionLibraryTest.ReflectionExtTest
{
    public class MiscReflectionTest
    {
        [Fact]
        public void IsNullable()
        {
            /*Assert.True(typeof(int?).LtcIsNullableOfValueType());
            Assert.True(typeof(Nullable<int>).LtcIsNullableOfValueType());
            //Assert.False(typeof(int).LtcIsNullableOfValueType());

            Assert.True(typeof(DateTime?).LtcIsNullableOfValueType());
            Assert.True(typeof(Nullable<DateTime>).LtcIsNullableOfValueType());
            Assert.False(typeof(DateTime).LtcIsNullableOfValueType());*/


            Assert.True(typeof(int?).LtcIsNullable());
            Assert.True(typeof(Nullable<int>).LtcIsNullable());
            Assert.False(typeof(int).LtcIsNullable());

            Assert.True(typeof(DateTime?).LtcIsNullable());
            Assert.True(typeof(Nullable<DateTime>).LtcIsNullable());
            Assert.False(typeof(DateTime).LtcIsNullable());

            Assert.False(typeof(string).LtcIsNullable());///////
        }
    }
}
