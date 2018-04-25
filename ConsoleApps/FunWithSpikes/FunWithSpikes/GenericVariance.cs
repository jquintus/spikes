using NUnit.Framework;

namespace FunWithSpikes
{
    [TestFixture]
    public class GenericVariance
    {
        #region Classes

        public interface IBar<out TFoo> where TFoo : IFoo
        {
            TFoo Foo { get; }
        }

        public interface IFoo { }

        public class Bar<TFoo> : IBar<TFoo> where TFoo : IFoo
        {
            public Bar(TFoo foo)
            {
                Foo = foo;
            }

            public TFoo Foo { get; }
        }

        public class Foo : IFoo { }

        #endregion Classes

        [Test]
        public void Cast_TypeHasConcreteGenericParameter_Succeeds()
        {
            // Assemble
            var specificBar = new Bar<Foo>(new Foo());

            // Act (we don't want this to throw)
            var genericBar = (IBar<IFoo>)specificBar;
        }
    }
}