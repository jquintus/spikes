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

        public bool TryRead(string name, out object value)
        {
            value = Read(name);
            return value == null;
        }

        public bool TryWrite(string name, object value)
        {
            Write(name, value);
            return true;
        }

        private object Read(string name)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(_root))
            {
                return key.GetValue(name);
            }
        }

        private void Write(string name, object value)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(_root))
            {
                key.SetValue(name, value);
            }
        }
    }
}