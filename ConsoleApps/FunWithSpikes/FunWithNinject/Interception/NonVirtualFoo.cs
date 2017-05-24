namespace FunWithNinject.Interception
{
    public class NonVirtualFoo : IFoo
    {
        public int Bar(string input) => 17;
    }
}