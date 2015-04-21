namespace FunWithNinject
{
    using System;
    using System.Collections.Generic;

    public class Bar
    {
        public Bar(Func<Foo> fooMaker)
        {
            Foos = new List<Foo>();

            Foos.Add(fooMaker());
            Foos.Add(fooMaker());
        }

        public List<Foo> Foos { get; set; }

        public void Do()
        {
            Console.WriteLine("How many foos does it take?  {0}", Foos.Count);
        }
    }
}