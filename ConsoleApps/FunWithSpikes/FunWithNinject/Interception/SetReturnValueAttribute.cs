using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Attributes;
using Ninject.Extensions.Interception.Request;

namespace FunWithNinject.Interception
{
    public class SetReturnValueAttribute : InterceptAttribute
    {
        private readonly int _returnValue;

        public SetReturnValueAttribute(int returnValue)
        {
            _returnValue = returnValue;
        }

        public override IInterceptor CreateInterceptor(IProxyRequest request)
        {
            return new OverrideReturnInterceptor<int>(_returnValue);
        }
    }
}