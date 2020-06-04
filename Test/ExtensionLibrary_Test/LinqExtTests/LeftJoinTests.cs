using ExtensionLibrary.LinqExt;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExtensionLibraryTest.LinqExtTests
{
    public class LeftJoinTests
    {
        List<StructMain> mainCollection = new List<StructMain>()
        {
            new StructMain{id = 1},
            new StructMain{id = 2},
            new StructMain{id = 3}
        };


        List<StructJoined> loopedChild = new List<StructJoined>()
        {
            new StructJoined{id = 101, mainId = 1},
            new StructJoined{id = 102, mainId = 2}
        };
        [Fact]
        public void LoopedJoinTest()
        {
            var joined = mainCollection.LtcLeftJoin(loopedChild,
                x => x.id,
                j => j.mainId,
                (x, j) => new StructResult(x, j)
                )
                .ToList();


            List<StructResult> expecrted = new List<StructResult>
            {
                new StructResult{mainId=1, joinedId=101, joinedMainId=1},
                new StructResult{mainId=2, joinedId=102, joinedMainId=2},
                new StructResult{mainId=3},
            };
            Assert.Equal(expecrted, joined, new CollectionEquivalenceComparer<StructResult>());
        }


        List<StructJoined> eqaulsChild = new List<StructJoined>()
        {
            new StructJoined{id = 101, mainId = 1},
            new StructJoined{id = 102, mainId = 2},
            new StructJoined{id = 103, mainId =3}
        };
        [Fact]
        public void EqalsJoinTest()
        {
            var joined = mainCollection.LtcLeftJoin(eqaulsChild,
                x => x.id,
                j => j.mainId,
                (x, j) => new StructResult(x, j)
                )
                .ToList();


            List<StructResult> expecrted = new List<StructResult>
            {
                new StructResult{mainId=1, joinedId=101, joinedMainId=1},
                new StructResult{mainId=2, joinedId=102, joinedMainId=2},
                new StructResult{mainId=3, joinedId=103, joinedMainId =3},
            };
            Assert.Equal(expecrted, joined, new CollectionEquivalenceComparer<StructResult>());
        }


        List<StructJoined> grossesChild = new List<StructJoined>()
        {
            new StructJoined{id = 101, mainId = 1},
            new StructJoined{id = 102, mainId = 2},
            new StructJoined{id = 103, mainId = 3},
            new StructJoined{id = 104},
        };
        [Fact]
        public void GrossesJoinTest()
        {
            var joined = mainCollection.LtcLeftJoin(grossesChild,
                x => x.id,
                j => j.mainId,
                (x, j) => new StructResult(x, j)
                )
                .ToList();


            List<StructResult> expecrted = new List<StructResult>
            {
                new StructResult{mainId=1, joinedId=101, joinedMainId=1},
                new StructResult{mainId=2, joinedId=102, joinedMainId=2},
                new StructResult{mainId=3, joinedId=103, joinedMainId =3},
            };
            Assert.Equal(expecrted, joined, new CollectionEquivalenceComparer<StructResult>());
        }



    }


}
