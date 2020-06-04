using ExtensionLibrary.LinqExt;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ExtensionLibraryTest.LinqExtTests
{
    public class FullJoinTests
    {

        List<StructMain> mainCollection = new List<StructMain>()
        {
            new StructMain{id = 1},
            new StructMain{id = 2},
            new StructMain{id = 3}
        };


        List<StructJoined> one2OneChild = new List<StructJoined>()
        {
            new StructJoined{id = 101, mainId = 1},
            new StructJoined{id = 102, mainId = 2},
            new StructJoined{id = 103, mainId = 3}
        };
        [Fact]
        public void One_to_One_Join()
        {
            var joined = mainCollection.LtcFullOuterJoin(one2OneChild, x => x.id, j => j.mainId, (x, j, id) => new StructResult(x, j))
                .ToList();

            List<StructResult> expecrted = new List<StructResult>
            {
                new StructResult{mainId=1, joinedId=101, joinedMainId=1},
                new StructResult{mainId=2, joinedId=102, joinedMainId=2},
                new StructResult{mainId=3, joinedId = 103, joinedMainId = 3},
            };

            Assert.Equal(expecrted, joined, new CollectionEquivalenceComparer<StructResult>());
        }


        List<StructJoined> withoutOneChild = new List<StructJoined>()
        {
            new StructJoined{id = 101, mainId = 1},
            new StructJoined{id = 102, mainId = 2},
        };
        [Fact]
        public void Without_one_Join()
        {
            var joined = mainCollection.LtcFullOuterJoin(withoutOneChild, x => x.id, j => j.mainId, (x, j, id) => new StructResult(x, j))
                .ToList();

            List<StructResult> expecrted = new List<StructResult>
            {
                new StructResult{mainId=1, joinedId=101, joinedMainId=1},
                new StructResult{mainId=2, joinedId=102, joinedMainId=2},
                new StructResult{mainId=3},
            };

            Assert.Equal(expecrted, joined, new CollectionEquivalenceComparer<StructResult>());
        }


        List<StructJoined> witAddedChild = new List<StructJoined>()
        {
            new StructJoined{id = 101, mainId = 1},
            new StructJoined{id = 102, mainId = 2},
            new StructJoined{id = 103, mainId = 3},
            new StructJoined{id = 104, mainId = 4}
        };
        [Fact]
        public void Wit_added_Join()
        {
            var joined = mainCollection.LtcFullOuterJoin(witAddedChild, x => x.id, j => j.mainId, (x, j, id) => new StructResult(x, j))
                .ToList();

            List<StructResult> expecrted = new List<StructResult>
            {
                new StructResult{mainId=1, joinedId=101, joinedMainId=1},
                new StructResult{mainId=2, joinedId=102, joinedMainId=2},
                new StructResult{mainId=3, joinedId = 103, joinedMainId = 3},
                new StructResult{joinedId = 104, joinedMainId = 4}
            };

            Assert.Equal(expecrted, joined, new CollectionEquivalenceComparer<StructResult>());
        }


        List<StructJoined> variousChild = new List<StructJoined>()
        {
            
            new StructJoined{id = 102, mainId = 2},
            new StructJoined{id = 103, mainId = 3},
            new StructJoined{id = 104, mainId = 4}
        };
        [Fact]
        public void Various_Join()
        {
            var joined = mainCollection.LtcFullOuterJoin(variousChild, x => x.id, j => j.mainId, (x, j, id) => new StructResult(x, j))
                .ToList();

            List<StructResult> expecrted = new List<StructResult>
            {
                new StructResult{mainId=1, },
                new StructResult{mainId=2, joinedId=102, joinedMainId=2},
                new StructResult{mainId=3, joinedId = 103, joinedMainId = 3},
                new StructResult{joinedId = 104, joinedMainId = 4}
            };

            Assert.Equal(expecrted, joined, new CollectionEquivalenceComparer<StructResult>());
        }
    }
}
