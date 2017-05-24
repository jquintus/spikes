namespace FunWithNinject.Interception
{
    public class AttributedFoo : IFoo
    {
        [SetReturnValue(606)]
        public int Bar(string input) => 18;
    }
}