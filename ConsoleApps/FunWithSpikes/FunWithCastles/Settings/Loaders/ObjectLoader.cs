using System;
using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public class ObjectLoader<T> : ISettingsLoader
    {
        private T _data;

        public ObjectLoader(T data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            _data = data;
        }

        public IDictionary<string, object> Load()
        {
            return _data.ToPropertyDictionary();
        }
    }
}