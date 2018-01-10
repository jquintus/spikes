using Castle.DynamicProxy;

namespace FunWithCastles.Settings
{
    public class SettingsInterceptor : IInterceptor
    {
        private readonly ISettingsAdapter _adapter;

        public SettingsInterceptor(ISettingsAdapter adapter)
        {
            _adapter = adapter;
        }

        public void Intercept(IInvocation invocation)
        {
            var name = invocation.Method.Name;
            bool handled = false;
            if (name.StartsWith("get_"))
            {
                handled = Get(invocation, name);
            }
            else if (name.StartsWith("set_"))
            {
                handled = Set(invocation, name);
            }

            if (!handled)
            {
                invocation.Proceed();
            }
        }

        private static string Clean(string input, string prefix)
        {
            return input.Substring(prefix.Length);
        }

        private bool Get(IInvocation invocation, string name)
        {
            name = Clean(name, "get_");
            if (_adapter.CanRead(name))
            {
                invocation.ReturnValue = _adapter[name];
                return true;
            }

            return false;
        }

        private bool Set(IInvocation invocation, string name)
        {
            name = Clean(name, "set_");
            if (_adapter.CanWrite(name))
            {
                _adapter[name] = invocation.Arguments[0];
                return true;
            }

            return false;
        }
    }
}