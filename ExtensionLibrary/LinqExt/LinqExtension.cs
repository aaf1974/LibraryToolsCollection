using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ExtensionLibrary.LinqExt
{
    public static class LinqExtension
    {
        #region Join

        //https://stackoverflow.com/questions/3792888/how-to-implement-left-join-in-join-extension-method

        public static IEnumerable<TResult> LtcLeftJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
        IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector)
        {
            return outer
                .GroupJoin(inner, outerKeySelector, innerKeySelector, (outerObj, inners) =>
                new
                {
                    outerObj,
                    inners = inners.DefaultIfEmpty()
                })
            .SelectMany(a => a.inners.Select(innerObj => resultSelector(a.outerObj, innerObj)));
        }


        //https://stackoverflow.com/questions/5489987/linq-full-outer-join
        public static IEnumerable<TResult> LtcFullOuterJoin<TA, TB, TKey, TResult>(
        this IEnumerable<TA> a,
        IEnumerable<TB> b,
        Func<TA, TKey> selectKeyA,
        Func<TB, TKey> selectKeyB,
        Func<TA, TB, TKey, TResult> projection,
        TA defaultA = default(TA),
        TB defaultB = default(TB),
        IEqualityComparer<TKey> cmp = null)
        {
            cmp = cmp ?? EqualityComparer<TKey>.Default;
            var alookup = a.ToLookup(selectKeyA, cmp);
            var blookup = b.ToLookup(selectKeyB, cmp);

            var keys = new HashSet<TKey>(alookup.Select(p => p.Key), cmp);
            keys.UnionWith(blookup.Select(p => p.Key));

            var join = from key in keys
                       from xa in alookup[key].DefaultIfEmpty(defaultA)
                       from xb in blookup[key].DefaultIfEmpty(defaultB)
                       select projection(xa, xb, key);

            return join;
        }

        #endregion

        #region ForEach
        //https://extensionmethod.net/csharp/ienumerable-t/foreach-3
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> array, Action<T> act)
        {
            foreach (var i in array)
                act(i);
            return array;
        }

        public static IEnumerable<T> ForEach<T>(this IEnumerable arr, Action<T> act)
        {
            return arr.Cast<T>().ForEach<T>(act);
        }

        public static IEnumerable<RT> ForEach<T, RT>(this IEnumerable<T> array, Func<T, RT> func)
        {
            var list = new List<RT>();
            foreach (var i in array)
            {
                var obj = func(i);
                if (obj != null)
                    list.Add(obj);
            }
            return list;
        }

        #endregion

        [Obsolete("Не протестированно/Not testing", false)]
        public static IEnumerable<T> LtcOrderBy<T>(this IEnumerable<T> list, string sortExpression)
        {
            sortExpression += "";
            string[] parts = sortExpression.Split(' ');
            bool descending = false;
            string property = "";

            if (parts.Length > 0 && parts[0] != "")
            {
                property = parts[0];

                if (parts.Length > 1)
                {
                    descending = parts[1].ToLower().Contains("esc");
                }

                PropertyInfo prop = typeof(T).GetProperty(property);

                if (prop == null)
                {
                    throw new Exception("No property '" + property + "' in + " + typeof(T).Name + "'");
                }

                if (descending)
                    return list.OrderByDescending(x => prop.GetValue(x, null));
                else
                    return list.OrderBy(x => prop.GetValue(x, null));
            }

            return list;
        }


        //https://extensionmethod.net/csharp/igrouping/todictionary-for-enumerations-of-groupings
        [Obsolete("Не протестированно/Not testing", false)]
        /// <summary>
        /// Converts an enumeration of groupings into a Dictionary of those groupings.
        /// </summary>
        /// <typeparam name="TKey">Key type of the grouping and dictionary.</typeparam>
        /// <typeparam name="TValue">Element type of the grouping and dictionary list.</typeparam>
        /// <param name="groupings">The enumeration of groupings from a GroupBy() clause.</param>
        /// <returns>A dictionary of groupings such that the key of the dictionary is TKey type and the value is List of TValue type.</returns>
        public static Dictionary<TKey, List<TValue>> LtcToDictionary<TKey, TValue>(this IEnumerable<IGrouping<TKey, TValue>> groupings)
        {
            return groupings.ToDictionary(group => group.Key, group => group.ToList());
        }


        //https://extensionmethod.net/csharp/ienumerable-t/transpose
        [Obsolete("Не протестированно/Not testing", false)]
        public static IEnumerable<IEnumerable<T>> LtcTranspose<T>(this IEnumerable<IEnumerable<T>> values)
        {
            if (values.Count() == 0)
                return values;
            if (values.First().Count() == 0)
                return LtcTranspose(values.Skip(1));

            var x = values.First().First();
            var xs = values.First().Skip(1);
            var xss = values.Skip(1);
            return
             new[] {new[] {x}
           .Concat(xss.Select(ht => ht.First()))}
               .Concat(new[] { xs }
               .Concat(xss.Select(ht => ht.Skip(1)))
               .LtcTranspose());
        }


        public static IEnumerable<T> LtcDistinct<T, TKey>(this IEnumerable<T> @this, Func<T, TKey> keySelector)
        {
            return @this.GroupBy(keySelector).Select(grps => grps).Select(e => e.First());
        }


        //https://extensionmethod.net/csharp/ienumerable-t/indexof-t
        /// <summary>
        /// Returns the index of the first occurrence in a sequence by using the default equality comparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="list">A sequence in which to locate a value.</param>
        /// <param name="value">The object to locate in the sequence</param>
        /// <returns>The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, –1.</returns>
        public static int LtcIndexOf<TSource>(this IEnumerable<TSource> list, TSource value) where TSource : IEquatable<TSource>
        {
            return list.LtcIndexOf<TSource>(value, EqualityComparer<TSource>.Default);
        }

        /// <summary>
        /// Returns the index of the first occurrence in a sequence by using a specified IEqualityComparer.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="list">A sequence in which to locate a value.</param>
        /// <param name="value">The object to locate in the sequence</param>
        /// <param name="comparer">An equality comparer to compare values.</param>
        /// <returns>The zero-based index of the first occurrence of value within the entire sequence, if found; otherwise, –1.</returns>
        public static int LtcIndexOf<TSource>(this IEnumerable<TSource> list, TSource value, IEqualityComparer<TSource> comparer)
        {
            int index = 0;
            foreach (var item in list)
            {
                if (comparer.Equals(item, value))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        //https://extensionmethod.net/csharp/ilist-t/isnullorempty
        public static bool LtcIsNullOrEmpty<T>(this IList<T> items)
        {
            return items == null || !items.Any();
        }

        //https://extensionmethod.net/csharp/ilist-t/chainable-list-add-typesafe
        //var listTest = new List<string>().Push("test").Push("test2");
        /// <summary>
        /// var listTest = new List<string>().LtcAdd("test").LtcAdd("test2");
        /// </summary>
        /// <typeparam name="TList"></typeparam>
        /// <typeparam name="TItem"></typeparam>
        /// <param name="list"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        public static TList LtcAdd<TList, TItem>(this TList list, TItem item) 
            where TList : IList<TItem>
        {
            list.Add(item);
            return list;
        }
    }
}
