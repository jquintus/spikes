using FunWithCastles.Settings.Loaders;
using System.Collections;
using System.Collections.Generic;

namespace FunWithCastles.Settings.Adapters
{
    public class MemoryAdapter : ISettingsAdapter
    {
        private readonly IDictionary<string, object> _data;

        public MemoryAdapter(IDictionary<string, object> data = null)
        {
            _data = data ?? new Dictionary<string, object>();
        }

        public IDictionary<string, object> Data => _data;

        public object this[string name]
        {
            get { return _data[name]; }
            set { _data[name] = value; }
        }

        public bool CanRead(string name)
        {
            return _data.ContainsKey(name);
        }

        public bool CanWrite(string name)
        {
            return true;
        }
    }
}