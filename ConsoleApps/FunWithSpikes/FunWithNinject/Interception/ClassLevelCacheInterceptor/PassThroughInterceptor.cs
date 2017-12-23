using Ninject.Extensions.Interception;

namespace FunWithNinject.Interception.ClassLevelCacheInterceptor
{
    public class PassThroughInterceptor : SimpleInterceptor
    {
        public bool Called { get; set; }
        protected override void AfterInvoke(IInvocation invocation)
        {
            base.AfterInvoke(invocation);
            Called = true;
        }
    }
}
