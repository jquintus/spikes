using System.Collections.Generic;

namespace FunWithCastles.Settings
{
    public static class LinqExt
    {
        public static IEnumerable<T> Prepend<T> (this IEnumerable<T> src, T toAdd)
        {
            yield return toAdd;

            if (src!= null)
            {
                foreach (var item in src)
                {
                    yield return item;
                }
            }
        }
    }
}