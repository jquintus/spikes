namespace PlatformSpecific
{
    public class Platform
    {
        public string CompiledFor
        {
            get
            {
                var platform = "Unknown";
#if AnyCPU
                platform = "AnyCPU";
#endif
#if x64
                platform = "x64";
#endif
#if x86
                platform = "x86";
#endif

                return platform;
            }
        }
    }
}