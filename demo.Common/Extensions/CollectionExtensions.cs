using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demo.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> collection)
        {
            return collection == null || !collection.Any();
        }

        public static string JoinString<T>(this ICollection<T> collection, string separator)
        {
            return string.Join(separator, collection);
        }
        public static ICollection<ICollection<T>> PageSplit<T>(this ICollection<T> collection, int pageSize) {
            var list = new List<ICollection<T>>();
            var count = list.Sum(x=>x.Count);
            var index = 0;
            while (count<collection.Count)
            {
                list.Add(collection.Skip(index * pageSize).Take(pageSize).ToList());
                index++; 
                count = list.Sum(x => x.Count);
            }
            return list;
        }
    }
}
