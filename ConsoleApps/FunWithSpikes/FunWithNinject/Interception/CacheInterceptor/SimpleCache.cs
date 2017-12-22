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
            }
            else
            {
                invocation.ReturnValue = _returnValue;
            }
        }

        private object GetCachedValue(IInvocation invocation)
        {
            object value = null;
            var key = invocation.Request.Method;
            if (_returnValues.TryGetValue(key, out value))
            {
                _returnValues[key] = null;
                return value;
            }
            else
            {
                return null;
            }
        }
    }
}
