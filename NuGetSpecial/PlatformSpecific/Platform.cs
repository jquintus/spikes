namespace PlatformSpecific
{
    public class Platform
    {
#if AnyCPU
        public const string platform = "AnyCPU";
#endif
#if x64
        public const string platform = "x64";
#endif
#if x86
        public const string platform = "x86";
#endif

        public string CompiledFor
        {
            get
            {
                return platform;
            }
        }
    }
}