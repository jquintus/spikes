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
            if (name.StartsWith("get_"))
            {
                name = Clean(name, "get_");
                if (_adapter.CanRead(name))
                {
                    invocation.ReturnValue = _adapter.Read(name);
                }
                else
                {
                    invocation.Proceed();
                }
            }
            else if (name.StartsWith("set_"))
            {
                name = Clean(name, "set_");
                _adapter.Write(name, invocation.Arguments[0]);
            }
            else
            {
                invocation.Proceed();
            }
        }

        private static string Clean(string input, string prefix)
        {
            return input.Substring(prefix.Length);
        }
    }
}