using System.Collections.Generic;
using System.Linq;

namespace FunWithCastles.Settings
{
    public static class ReflectionExt
    {
        public static Dictionary<string, object> ToPropertyDictionary<T>(this T obj)
        {
            var dict = typeof(T).GetProperties()
                                .ToDictionary(
                                    p => p.Name,
                                    p=> p.GetValue(obj));
            return dict;
        }
    }
}