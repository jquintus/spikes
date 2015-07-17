using System.Diagnostics;
namespace FunWithSpikes
{
    [DebuggerDisplay("Foo:  {Value}")]
    public class Foo : IHaveValue
    {
        public string Value { get; set; }
    }
}