using System.Collections;

namespace FunWithCastles.Settings
{
    public class MemoryAdapter : ISettingsAdapter
    {
        private readonly Hashtable _data;

        public MemoryAdapter(Hashtable data = null)
        {
            _data = data ?? new Hashtable();
        }

        public bool CanRead(string name)
        {
            return _data.ContainsKey(name);
        }

        public object Read(string name)
        {
            return _data[name];
        }

        public void Write(string name, object value)
        {
            _data[name] = value;
        }
    }
}