using ExtensionLibrary.EnumExt;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExtensionLibraryTest.EnumExtTests
{
    public class GetEnumCollectionTests
    {
        List<SampleEnum> expectedAllElements = new List<SampleEnum> { SampleEnum.One, SampleEnum.Two, SampleEnum.Three };

        [Fact]
        public void GetCollectionTest()
        {
            List<SampleEnum> res = EnumExtension.LtcValues<SampleEnum>().ToList();

            res.Should().BeEquivalentTo(expectedAllElements);
        }

        [Fact]
        public void GetCollection_For_enum_Element()
        {
            List<SampleEnum> res = SampleEnum.Two.LtcValues().ToList();


            res.Should().BeEquivalentTo(expectedAllElements);
        }
    }
}
