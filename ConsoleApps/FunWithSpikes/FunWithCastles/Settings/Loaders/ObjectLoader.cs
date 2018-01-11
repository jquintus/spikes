using FunWithCastles.Settings.Utils;
using System;
using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public class ObjectLoader<T> : ISettingsLoader
    {
        private T _data;

        public ObjectLoader(T data)
        {
#pragma warning disable IDE0016 // Use 'throw' expression
            if (data == null) throw new ArgumentNullException(nameof(data));
#pragma warning restore IDE0016 // Use 'throw' expression
            _data = data;
        }

        public IDictionary<string, object> Load()
        {
            return _data.ToPropertyDictionary();
        }
    }
}