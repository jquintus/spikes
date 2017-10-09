using BenchmarkDotNet.Attributes;

namespace FunWithBenchmarks
{
    public class VirtualFun
    {
        private readonly BaseClass _abstractClass;
        private readonly ISomething _interface;
        private readonly TestClass _testClass;

        public VirtualFun()
        {
            _testClass = new TestClass();
            _abstractClass = new TestClass();
            _interface = new TestClass();
        }

        [Benchmark]
        public void BenchmarkAbstract()
        {
            _abstractClass.AbstractMethod();
        }

        [Benchmark]
        public void BenchmarkInterface()
        {
            _interface.InterfaceMethod();
        }

        [Benchmark(Baseline = true)]
        public void BenchmarkSealed()
        {
            _testClass.SealedMethod();
        }

        [Benchmark]
        public void TimeStatic()
        {
            TestClass.StaticMethod();
        }

        [Benchmark]
        public void TimeVirtual()
        {
            _testClass.VirtualMethod();
        }

        #region Nested Classes

        private interface ISomething
        {
            void InterfaceMethod();
        }

        public abstract class BaseClass
        {
            public abstract void AbstractMethod();
        }

        public class TestClass : BaseClass, ISomething
        {
            [Benchmark]
            public static void StaticMethod()
            {
            }

            [Benchmark]
            public override void AbstractMethod()
            {
            }

            [Benchmark]
            public void InterfaceMethod()
            {
            }

            public void SealedMethod()
            {
            }

            public virtual void VirtualMethod()
            {
            }
        }

        #endregion Nested Classes
    }
}