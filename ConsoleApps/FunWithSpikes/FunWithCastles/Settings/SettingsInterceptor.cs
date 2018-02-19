using Castle.DynamicProxy;
using System.Collections.Generic;

namespace FunWithCastles.Settings
{
    public class SettingsInterceptor : IInterceptor
    {
        private readonly IEnumerable<SettingsReaderWriter> _readerWriters;

        public SettingsInterceptor(IEnumerable<SettingsReaderWriter> readerWriters)
        {
            _readerWriters = readerWriters;
        }

        private enum PropertyType { Get, Set, NotAProperty }

        public void Intercept(IInvocation invocation)
        {
            var (name, propType) = GetPropertInfo(invocation);
            Intercept(invocation, name, propType);
        }

        private static string Clean(string input, string prefix)
        {
            return input.StartsWith(prefix)
                ? input.Substring(prefix.Length)
                : input;
        }

        private (string name, PropertyType type) GetPropertInfo(IInvocation invocation)
        {
            var propType = PropertyType.NotAProperty;
            string cleaned = null;

            var name = invocation.Method.Name;
            if (name.StartsWith("get_"))
            {
                propType = PropertyType.Get;
                cleaned = Clean(name, "get_");
            }
            else if (name.StartsWith("set_"))
            {
                propType = PropertyType.Set;
                cleaned = Clean(name, "set_");
            }
            return (cleaned, propType);
        }

        private void Intercept(IInvocation invocation, string name, PropertyType propType)
        {
            switch (propType)
            {
                case PropertyType.Get:
                    Read(invocation, name);
                    break;
                case PropertyType.Set:
                    Write(invocation, name);
                    break;
            }
        }

        private void Read(IInvocation invocation, string name)
        {
            object value;
            var returnType = invocation.Method.ReturnType;
            foreach (var reader in _readerWriters)
            {
                if (reader.Read(returnType, name, out value))
                {
                    invocation.ReturnValue = value;
                    return;
                }
            }
        }

        private void Write(IInvocation invocation, string name)
        {
            object value = invocation.Arguments[0];
            var returnType = invocation.Method.ReturnType;
            foreach (var writer in _readerWriters)
            {
                if (writer.Write(returnType, name, value))
                {
                    return;
                }
            }
        }
    }
}