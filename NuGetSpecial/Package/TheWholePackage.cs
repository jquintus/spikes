using PlatformSpecific;

namespace Package
{
    public class TheWholePackage
    {
        public string BuildType => (new Platform()).CompiledFor;
    }
}