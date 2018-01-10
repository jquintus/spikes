using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public static class DictionaryLoaderSettingsBuilderExt
    {
        public static ISettingsBuilder LoadFromDictionary(
            this ISettingsBuilder builder,
            IDictionary<string, object> dict)
        {
            return builder.Load(new DictionaryLoader(dict));
        }
    }
}