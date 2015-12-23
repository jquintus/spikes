using CommandLine;

namespace FunWithCommandLine
{
    public enum Letter
    {
        A,
        B,
        C,
    }

    public class OptionsWithDefaultEnum
    {
        [Option("letter", DefaultValue = Letter.B)]
        public Letter DefaultedLetter { get; set; }
    }


    public class OptionsWithEnums
    {
        [Option("letter")]
        public Letter DefaultedLetter { get; set; }
    }
}