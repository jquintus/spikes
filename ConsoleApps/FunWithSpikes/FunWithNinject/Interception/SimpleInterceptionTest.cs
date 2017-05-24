using Ninject;
using Ninject.Extensions.Interception;
using Ninject.Extensions.Interception.Infrastructure.Language;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunWithNinject.Interception
{
    [TestFixture]
    public class SimpleInterceptionTest
    {
        /*
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         * I wasn't able to figure out how to get interception to work yet
         */

        [Test]
        public void Test()
        {
            // Assemble
            using (var k = new StandardKernel())
            {

                //var interceptor = new ActionInterceptor(i => Console.WriteLine("hello world"));
                k.Bind<Foo>().ToSelf().Intercept().With<MyInterceptor>();
                //k.Bind<Foo>().ToSelf().Intercept().With(interceptor);

                k.InterceptAround<Foo>(
                    f => f.Bar("Hello"),
                    invocation => Console.WriteLine("Calling f.bar {0}", invocation.Request.Arguments),
                    invocation => invocation.ReturnValue = 100
                    );

                // Act
                var foo = k.Get<Foo>();

                // Assert
                Assert.AreEqual(5, foo.Bar("Hello"));
            }
        }
    }


    public class Foo
    {
        public int Bar(string input)
        {
            return input?.Length ?? -1;
        }

        public bool Somthing { get; }
    }
    public class MyInterceptor : SimpleInterceptor
    {
        protected override void BeforeInvoke(IInvocation invocation)
        {
            base.BeforeInvoke(invocation);

            Console.WriteLine("Before invoke");

            if (invocation.Request.Method.IsPublic)
            {
                var target = invocation.Request.Target;
                Console.WriteLine($"calling a public method on {target}");
                var fooTarget = target as Foo;

                if (fooTarget != null)
                {
                    if (fooTarget.Somthing)
                    {
                        throw new Exception("Something was set");
                    }
                }
            }
        }

        protected override void AfterInvoke(IInvocation invocation)
        {
            base.AfterInvoke(invocation);




            Console.WriteLine("After invoke");
        }

    }
}
