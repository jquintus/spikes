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

        public bool TryRead(string name, out object value)
        {
            value = Read(name);
            return null != value;
        }

        public bool TryWrite(string name, object value)
        {
            Write(name, value);
            return true;
        }

        private object Read(string name)
        {
            name = _prefix + name;
            var variable = Environment.GetEnvironmentVariable(name);
            return variable;
        }

        private void Write(string name, object value)
        {
            name = _prefix + name;
            var strValue = value?.ToString();
            Environment.SetEnvironmentVariable(name, strValue);
        }
    }
}