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

        public object this[string name]
        {
            get
            {
                name = _prefix + name;
                var variable = Environment.GetEnvironmentVariable(name);
                return variable;
            }
            set
            {
                name = _prefix + name;
                var strValue = value?.ToString();
                Environment.SetEnvironmentVariable(name, strValue);
            }
        }

        public bool CanRead(string name)
        {
            var variable = this[name];
            return null == variable;
        }

        public bool CanWrite(string name)
        {
            return true;
        }
    }
}