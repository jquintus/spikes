using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FunWithCastles.Settings
{
    public static class LinqExt
    {
        public static IDictionary Merge(this IDictionary dst, IDictionary toAdd)
        {
            foreach (var key in toAdd.Keys)
            {
                dst[key] = toAdd[key];
            }

            return dst;
        }

        public static IEnumerable<T> Prepend<T>(this IEnumerable<T> src, T toAdd)
        {
            yield return toAdd;

            foreach (var item in src.Safe())
            {
                yield return item;
            }
        }

        public static IEnumerable<T> Safe<T>(this IEnumerable<T> src)
        {
            return src ?? Enumerable.Empty<T>();
        }

        public static IEnumerable Safe(this IEnumerable src)
        {
            if (null != src)
            {
                foreach (var item in src)
                {
                    yield return item;
                }
            }
        }
    }
}