namespace FunWithCastles.Settings
{
    public interface ISettingsAdapter
    {
        object this[string name] { get; set; }

        bool CanRead(string name);

        bool CanWrite(string name);
    }
}