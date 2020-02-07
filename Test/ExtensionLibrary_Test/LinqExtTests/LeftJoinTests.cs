using ExtensionLibrary.LinqExt;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Xunit;

namespace ExtensionLibrary_Test.LinqExtTests
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


        class StructMain
        {
            public int id { get; set; }

            public string name { get; set; }
        }

        class StructJoined
        {
            public int id { get; set; }

            public int mainId { get; set; }

            public bool? mark { get; set; }
        }

        class StructResult : IEquatable<StructResult>, IComparable
        {
            public StructResult() 
            {
                joinedMark = null;
            }
            public StructResult(StructMain main, StructJoined joined)
            {
                mainId = main?.id;
                mainName = main?.name;

                joinedId = joined?.id;
                joinedMainId = joined?.mainId;
                joinedMark = joined?.mark;
            }

            public int? mainId { get; set; }

            public string mainName { get; set; }

            public int? joinedId { get; set; }

            public int? joinedMainId { get; set; }

            public bool? joinedMark { get; set; }

            public bool Equals([AllowNull] StructResult other)
            {
                if (!mainId.Equals(other.mainId))
                    return false;
                if ((mainName != null && other.mainName != null && !mainName.Equals(other.mainName))
                    
                    )
                    return false;
                if (!joinedId.Equals(other.joinedId))
                    return false;
                if (!joinedMainId.Equals(other.joinedMainId))
                    return false;
                if (joinedMark != null && other.joinedMark != null && !joinedMark.Equals(other.joinedMark))
                    return false;

                return true;
            }

            public int CompareTo(object obj)
            {
                if (obj == null) return 1;
                
                StructResult other = obj as StructResult;
                if (other == null)
                    throw new ArgumentException("Object is not a Temperature");

                if (mainId != other.mainId)
                    return mainId > other.mainId ? 1 : -1;

                if (joinedId != other.joinedId)
                    return joinedId > other.joinedId ? 1 : -1;

                return 0;
            }

        }

        class CollectionEquivalenceComparer<T> : IEqualityComparer<IEnumerable<T>>
            where T : IEquatable<T>
        {
            public bool Equals(IEnumerable<T> x, IEnumerable<T> y)
            {
                List<T> leftList = new List<T>(x);
                List<T> rightList = new List<T>(y);
                leftList.Sort();
                rightList.Sort();

                IEnumerator<T> enumeratorX = leftList.GetEnumerator();
                IEnumerator<T> enumeratorY = rightList.GetEnumerator();

                while (true)
                {
                    bool hasNextX = enumeratorX.MoveNext();
                    bool hasNextY = enumeratorY.MoveNext();

                    if (!hasNextX || !hasNextY)
                        return (hasNextX == hasNextY);

                    if (!enumeratorX.Current.Equals(enumeratorY.Current))
                        return false;
                }
            }

            public int GetHashCode(IEnumerable<T> obj)
            {
                throw new NotImplementedException();
            }
        }
    }


}
