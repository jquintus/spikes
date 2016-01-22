using Ninject;
using Ninject.Activation;
using System.Collections.Generic;
using System.Linq;

namespace FunWithNinject.Provider
{
    public class NamedFooProvider : Provider<IFoo>
    {
        public const string Foo1 = "First";
        public const string Foo2 = "Second";
        private readonly IFoo _first;
        private readonly IFoo _second;

        public NamedFooProvider(
        [Named(Foo1)]IFoo firstFoo,
        [Named(Foo2)]IFoo secondFoo)
        {
            _first = firstFoo;
            _second = secondFoo;
        }

        protected override IFoo CreateInstance(IContext context)
        {
            var name = GetContexts(context)
                .Select(c => c.Binding?.Metadata?.Name)
                .First(n => n != null);

            if (name == Foo2)
            {
                return _second;
            }
            {
                return _first;
            }
        }

        private IEnumerable<IContext> GetContexts(IContext context)
        {
            while (context != null)
            {
                yield return context;
                context = context.Request.ParentContext;
            }
        }
    }
}