using ExtensionLibrary.EnumExt;
using Xunit;

namespace ExtensionLibraryTest.EnumExtTests
{
    public class GetEnumDescriptionTests
    {
        [Fact]
        public void GetDescription_format_default()
        {
            var res = SampleEnum.One.LtcGetDescription();

            Assert.Equal("OneDecription", res);
        }

        [Fact]
        public void GetDescription_when_not_description()
        {
            var res = SampleEnum.Two.LtcGetDescription();

            Assert.Equal(string.Empty, res);
        }

        [Fact]
        public void GetDescription_format_name()
        {
            var res = SampleEnum.One.LtcGetDescription(EnumsNET.EnumFormat.Name);

            Assert.Equal("One", res);
        }

        [Fact]
        public void GetDescription_format_decimalValue()
        {
            var res = SampleEnum.One.LtcGetDescription(EnumsNET.EnumFormat.DecimalValue);

            Assert.Equal("0", res);
        }


        [Fact]
        public void GetDescription_format_display()
        {
            var res = SampleEnum.Three.LtcGetDescription(EnumsNET.EnumFormat.DisplayName);

            Assert.Equal("ThreeDisplay", res);
        }
    }
}
