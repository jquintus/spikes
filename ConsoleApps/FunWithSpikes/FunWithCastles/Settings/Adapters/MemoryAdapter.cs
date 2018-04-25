using System.Collections.Generic;

namespace FunWithCastles.Settings.Adapters
{
    public class MemoryAdapter : ISettingsAdapter
    {
        public MemoryAdapter(IDictionary<string, object> data = null)
        {
            Data = data ?? new Dictionary<string, object>();
        }

        public IDictionary<string, object> Data { get; }

        public bool TryRead(string name, out object value)
        {
            return Data.TryGetValue(name, out value);
        }

        public bool TryWrite(string name, object value)
        {
            Data[name] = value;
            return true;
        }
    }
}