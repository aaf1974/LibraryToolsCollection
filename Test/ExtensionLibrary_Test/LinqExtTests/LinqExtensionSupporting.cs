using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ExtensionLibraryTest.LinqExtTests
{
    class LinqExtensionSupporting
    {
    }


    class NoIEquatableStruct
    {
        public int id { get; set; }

        public string name { get; set; }
    }

    class StructMain : IEquatable<StructMain>, IComparable
    {
        public int id { get; set; }

        public string name { get; set; }

        public bool Equals([AllowNull] StructMain other)
        {
            if (!id.Equals(other.id))
                return false;
            if (name != null && other.name != null && !name.Equals(other.name))
                return false;

            return true;
        }


        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            StructMain other = obj as StructMain;
            if (other == null)
                throw new ArgumentException("Object is not a StructMain");

            if (id != other.id)
                return id > other.id ? 1 : -1;

            //if (name != other.name)
            //    return name > other.name ? 1 : -1;

            return 0;
        }

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
            if ((mainName != null && other.mainName != null && !mainName.Equals(other.mainName)))
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
