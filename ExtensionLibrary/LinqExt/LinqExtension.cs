using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtensionLibrary.LinqExt
{
    public static class LinqExtension
    {
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
    }
}
