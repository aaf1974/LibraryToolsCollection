using ExtensionLibrary.LinqExt;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ExtensionLibraryTest.LinqExtTests
{
    public class MiscLinqExtTests
    {
        List<StructMain> intTestCollection = new List<StructMain>()
        {
            new StructMain{id = 5},
            new StructMain{id = 2},
            new StructMain{id = 1}
        };

        [Fact]
        public void OrderByInt()
        {
            List<StructMain> expecrted = new List<StructMain>
            {
                new StructMain{id = 1},
                new StructMain{id = 2},
                new StructMain{id = 5},
            };

            List<StructMain> descExpecrted = new List<StructMain>
            {
                new StructMain{id = 5},
                new StructMain{id = 2},
                new StructMain{id = 1},
            };

            //var res = intTestCollection.LtcOrderBy($"{nameof(StructMain.id)}");
            //Assert.Equal(expecrted, res);
            //Assert.NotEqual(descExpecrted, res);


            //res = intTestCollection.LtcOrderBy($"{nameof(StructMain.id)} desc");
            //Assert.NotEqual(expecrted, res);
            //Assert.Equal(descExpecrted, res);
        }


        List<StructMain> stringTestCollection = new List<StructMain>()
        {
            new StructMain{name = "G"},
            new StructMain{name = "A"},
            new StructMain{name = "C"}
        };

        [Fact]
        public void OrderByString()
        {
            List<StructMain> expecrted = new List<StructMain>
            {
                new StructMain{name = "A"},
                new StructMain{name = "C"},
                new StructMain{name = "G"}
            };

            List<StructMain> descExpecrted = new List<StructMain>
            {
                new StructMain{name = "G"},
                new StructMain{name = "C"},
                new StructMain{name = "A"}
            };

            //var res = stringTestCollection.LtcOrderBy($"{nameof(StructMain.name)}");
            //Assert.Equal(expecrted, res);
            //Assert.Equal(descExpecrted, res);


            //res = stringTestCollection.LtcOrderBy($"{nameof(StructMain.name)} desc");
            //Assert.NotEqual(expecrted, res);
            //Assert.Equal(descExpecrted, res);
        }


        List<StructMain> distCollection = new List<StructMain>()
        {
            new StructMain{id = 5},
            new StructMain{id = 2},
            new StructMain{id = 1},
            new StructMain{id = 1},
            new StructMain{id = 5},
        };
        [Fact]
        public void DistinctTest()
        {
            var res = distCollection.LtcDistinct(i => i.id);

            List<StructMain> distExpected = new List<StructMain>()
            {
                new StructMain{id = 5},
                new StructMain{id = 2},
                new StructMain{id = 1},
            };

            Assert.Equal(res, distExpected, new CollectionEquivalenceComparer<StructMain>());
        }


        [Fact]
        public void IndexOf()
        {
            int[] numbers = new int[] { 5, 3, 12, 56, 43 };

            int index = numbers.LtcIndexOf(123);
            Assert.Equal(-1, index);

            index = numbers.LtcIndexOf(12);
            Assert.Equal(2, index);
        }

        [Fact]
        public void IsNullOrEmpty()
        {
            List<StructMain> list = null;
            Assert.True(list.LtcIsNullOrEmpty());

            list = new List<StructMain>();
            Assert.True(list.LtcIsNullOrEmpty());

            list.Add(new StructMain { id = 1 });
            Assert.False(list.LtcIsNullOrEmpty());
        }
    }
}
