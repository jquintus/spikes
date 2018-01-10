using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public static class DictionaryLoaderSettingsBuilderExt
    {
        public static SettingsBuilder LoadFromDictionary(
            this SettingsBuilder builder,
            IDictionary<string, object> dict)
        {
            return builder.Load(new DictionaryLoader(dict));
        }
    }
}