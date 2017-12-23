using Ninject.Extensions.Interception;
using System.Collections.Generic;
using System.Reflection;

namespace FunWithNinject.Interception.CacheInterceptor
{
    public class SimpleCache : IInterceptor
    {
        private readonly Dictionary<MethodInfo, object> _returnValues;
        public SimpleCache()
        {
            _returnValues = new Dictionary<MethodInfo, object>();
        }

        public void Intercept(IInvocation invocation)
        {
            var _returnValue = GetCachedValue(invocation);
            if (_returnValue == null)
            {
                invocation.Proceed();
                SetCachedValue(invocation);
            }
            else
            {
                invocation.ReturnValue = _returnValue;
            }
        }

        private object GetCachedValue(IInvocation invocation)
        {
            var key = invocation.Request.Method;
            if (_returnValues.TryGetValue(key, out object value))
            {
                _returnValues.Remove(key);
                return value;
            }
            else
            {
                return null;
            }
        }

        private void SetCachedValue(IInvocation invocation)
        {
            var key = invocation.Request.Method;
            _returnValues[key] = invocation.ReturnValue;
        }
    }
}
