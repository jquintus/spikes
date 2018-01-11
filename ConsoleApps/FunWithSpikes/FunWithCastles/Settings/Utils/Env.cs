using System;

namespace FunWithCastles.Settings.Utils
{
    public class Env : IDisposable
    {
        private readonly string _name;
        private readonly string _originalValue;

        public Env(string name, string originalValue)
        {
            _name = name;
            _originalValue = originalValue;
        }

        public static IDisposable SetVariable(string name, string value)
        {
            var originalValue = Environment.GetEnvironmentVariable(name);

            if (originalValue == value)
            {
                throw new ArgumentException($"Trying to set ${name} to {value} but it is already set to that value");
            }

            Environment.SetEnvironmentVariable(name, value);

            return new Env(name, originalValue);
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable(_name, _originalValue);
        }
    }
}