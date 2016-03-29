using System.Collections.Generic;

namespace FunWithNinject.InjectingSequences
{
    public class ListOfFoo
    {
        public ListOfFoo(List<Foo> foos)
        {
            Foos = foos;
        }

        public List<Foo> Foos { get; }
    }
}