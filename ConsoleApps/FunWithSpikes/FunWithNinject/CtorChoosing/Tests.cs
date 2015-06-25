namespace FunWithNinject.CtorChoosing
{
    using Ninject;
    using NUnit.Framework;

    [TestFixture]
    public class Tests
    {
        [Test]
        public void MultipleCtors_SameArgumentsPlusOneUnbound_ThrowsActivationException()
        {
            // Assemble
            var k = new StandardKernel();
            k.Bind<IFoo>().To<Foo>();

            // Act / Assert (Actsert!)
            Assert.Throws<ActivationException>(() => k.Get<MyObj>());
        }

        [Test]
        public void MultipleCtors_SameArgumentsPlusOneUnboundAllowingNulls_Returns()
        {
            // Assemble
            var k = new StandardKernel();
            k.Settings.AllowNullInjection = true;

            k.Bind<IFoo>().To<Foo>();
            k.Bind<IBar>().ToConstant((IBar)null);

            // Act
            var o = k.Get<MyObj>();

            // Assert
            Assert.IsNull(o.Bar);
        }
    }
}