using Ninject.Extensions.Interception;
namespace FunWithNinject.Interception
{
    public class ReturnMaxIntInterceptor : SimpleInterceptor
    {
        protected override void AfterInvoke(IInvocation invocation)
        {
            base.BeforeInvoke(invocation);
            invocation.ReturnValue = int.MaxValue;
        }
    }
}