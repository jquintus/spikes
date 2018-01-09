using System;

namespace FunWithCastles.Settings.Adapters
{
    public class EnvironmentVariableAdapter : ISettingsAdapter
    {
        private readonly string _prefix;

        public EnvironmentVariableAdapter(string prefix = null)
        {
            _prefix = prefix;
        }

        public bool CanRead(string name)
        {
            var variable = Read(name);
            return null == variable;
        }

        public object Read(string name)
        {
            name = _prefix + name;
            var variable = Environment.GetEnvironmentVariable(name);
            return variable;
        }

        public void Write(string name, object value)
        {
            name = _prefix + name;
            var strValue = value?.ToString();
            Environment.SetEnvironmentVariable(name, strValue);
        }
    }
}