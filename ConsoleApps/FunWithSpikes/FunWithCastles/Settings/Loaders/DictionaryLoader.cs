using System;
using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public class DictionaryLoader : ISettingsLoader
    {
        private readonly IDictionary<string, object> _data;

        public DictionaryLoader(IDictionary<string, object> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            _data = data;
        }

        public IDictionary<string, object> Load()
        {
            return _data;
        }
    }
}