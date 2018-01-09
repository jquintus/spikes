using Castle.DynamicProxy;
using System;
using static FunWithCastles.FieldNames;

namespace FunWithCastles
{
    public class DumbInterceptor : IInterceptor
    {
        private int _maxItems;
        private DateTime _lastModified;
        private string _name = null;

        public DumbInterceptor(
            int maxItems = 0,
            string name = null,
            DateTime lastModified = default(DateTime))
        {
            _maxItems = maxItems;
            _name = name;
            _lastModified = lastModified;
        }

        public void Intercept(IInvocation invocation)
        {
            var name = invocation.Method.Name;
            if (name.StartsWith("get_"))
            {
                name = Clean(name, "get_");
                invocation.ReturnValue = InvokeGet(name);
            }
            else if (name.StartsWith("set_"))
            {
                name = Clean(name, "set_");
                InvokeSet(name, invocation.Arguments[0]);
            }
        }

        private static string Clean(string input, string prefix)
        {
            return input.Substring(prefix.Length);
        }

        private static void TrySet<T>(object value, ref T field)
        {
            if (value is T)
            {
                field = (T)value;
            }
        }

        private object InvokeGet(string name)
        {
            switch (name)
            {
                case DATE: return _lastModified;
                case NAME: return _name;
                case MAX: return _maxItems;
                default: return null;
            }
        }

        private void InvokeSet(string name, object argument)
        {
            switch (name)
            {
                case DATE:
                    TrySet(argument, ref _lastModified);
                    break;

                case NAME:
                    TrySet(argument, ref _name);
                    break;

                case MAX:
                    TrySet(argument, ref _maxItems);
                    break;

                default:
                    break;
            }
        }
    }
}