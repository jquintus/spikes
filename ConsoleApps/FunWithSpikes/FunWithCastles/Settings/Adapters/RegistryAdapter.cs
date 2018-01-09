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

        public bool CanRead(string name)
        {
            var value = Read(name);
            return value == null;
        }

        public object Read(string name)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(_root))
            {
                return key.GetValue(name);
            }
        }

        public void Write(string name, object value)
        {
            using (var key = Registry.CurrentUser.OpenSubKey(_root))
            {
                key.SetValue(name, value);
            }
        }
    }
}