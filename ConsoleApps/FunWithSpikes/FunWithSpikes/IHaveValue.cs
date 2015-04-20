namespace FunWithSpikes
{
    public interface IHaveValue
    {
        string Value { get; set; }
    }

    public static class HaveValueExtensions
    {
        public static T WithValue<T>(this T me, string value) where T : IHaveValue
        {
            me.Value = value;
            return me;
        }
    }
}