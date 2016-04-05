using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheatPads.Framework.Extensions
{
    public static class CollectionExtensions
    {
        public static bool ContainsAny<TItem>(this IEnumerable<TItem> collection, ICollection<TItem> items)
        {
            return collection.Any(x => items.Contains(x));
        }

        public static bool ContainsAny<TItem, TValue>(this IEnumerable<TItem> collection, Func<TItem,TValue> selector, ICollection<TValue> values)
        {
            return collection.Select(selector).Any(x => values.Contains(x));
        }

    }
}
