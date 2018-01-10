using Microsoft.Win32;

namespace FunWithCastles.Settings.Adapters
{
    public class RegistryAdapter : ISettingsAdapter
    {
        private readonly string _root;

        public RegistryAdapter(string root)
        {
            _root = root;
        }

        public object this[string name]
        {
            get
            {
                using (var key = Registry.CurrentUser.OpenSubKey(_root))
                {
                    return key.GetValue(name);
                }
            }
            set
            {
                using (var key = Registry.CurrentUser.OpenSubKey(_root))
                {
                    key.SetValue(name, value);
                }
            }
        }

        public bool CanRead(string name)
        {
            var value = this[name];
            return value == null;
        }

        public bool CanWrite(string name)
        {
            return true;
        }
    }
}