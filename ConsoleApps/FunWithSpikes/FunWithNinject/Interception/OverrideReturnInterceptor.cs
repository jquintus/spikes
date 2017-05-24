using Ninject.Extensions.Interception;

namespace FunWithNinject.Interception
{
    public class OverrideReturnInterceptor<T> : SimpleInterceptor
    {
        private readonly T _returnValue;

        public OverrideReturnInterceptor(T returnValue)
        {
            _returnValue = returnValue;
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            base.AfterInvoke(invocation);
            invocation.ReturnValue = _returnValue;
        }
    }
}