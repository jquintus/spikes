using CommandLine;

namespace FunWithCommandLine.SubclassedOptions
{
    public class ChildOptions : ParentOptions
    {
        public const string SEALED_DEFAULT_VALUE= "child - sealed option";

        public ChildOptions()
        {
            SealedOption = SEALED_DEFAULT_VALUE;
        }

        [Option(VIRTUAL_OPTION, DefaultValue = "child - virtual option")]
        public override string VirtualOption { get; set; }
    }

    public class ParentOptions
    {
        public const string SEALED_OPTION = "sealedOption";
        public const string VIRTUAL_OPTION = "virtualOption";

        [Option(SEALED_OPTION, DefaultValue = "parent - sealed option")]
        public string SealedOption { get; set; }

        [Option(VIRTUAL_OPTION, DefaultValue = "parent - virtual option")]
        public virtual string VirtualOption { get; set; }
    }
}