using System.Collections.Generic;

namespace FunWithNinject.InjectingSequences
{
    public class IEnumerableOfFoo
    {
        public IEnumerableOfFoo(IEnumerable<Foo> foos)
        {
            Foos = foos;
        }

        public IEnumerable<Foo> Foos { get; }
    }
}