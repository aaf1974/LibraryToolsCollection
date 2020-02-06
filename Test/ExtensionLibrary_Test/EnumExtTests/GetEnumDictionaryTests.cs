using ExtensionLibrary.EnumExt;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace ExtensionLibraryTest.EnumExtTests
{
    public class GetEnumDictionaryTests
    {
        Dictionary<SampleEnum, string> expectedDictionary = new Dictionary<SampleEnum, string>()
        {
            { SampleEnum.One, "OneDecription"},
            { SampleEnum.Two, string.Empty},
            { SampleEnum.Three, "ThreeDisplay"},
        };


        [Fact]
        public void GetDictionaryTest()
        {
            Dictionary<SampleEnum, string> dic = SampleEnum.One.LtcGetEnumDictionary();

            dic.Should().BeEquivalentTo(expectedDictionary);
        }
    }
}
