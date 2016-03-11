
namespace Intermediary
{
    public class Class1
    {
        public static string DiggingDeep
        {
            get
            {
                return (new Package.TheWholePackage()).BuildType;
                //return "nope";
            }
        }
    }
}