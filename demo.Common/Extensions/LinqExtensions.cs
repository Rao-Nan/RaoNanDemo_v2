using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo.Common.Extensions
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> WhereIf<T>(this IEnumerable<T> enumerable, bool condition, Func<T,bool> predicate) {
            return condition ? enumerable.Where(predicate) : enumerable;
        }

    }
}
