using System.Collections;

namespace FunWithCastles.Settings.Adapters
{
    public class MemoryAdapter : ISettingsAdapter
    {
        private readonly Hashtable _data;

        public MemoryAdapter(Hashtable data = null)
        {
            _data = data ?? new Hashtable();
        }

        public IDictionary Data => _data;

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