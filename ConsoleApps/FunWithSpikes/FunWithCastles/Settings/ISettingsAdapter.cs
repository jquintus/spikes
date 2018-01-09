namespace FunWithCastles.Settings
{
    public interface ISettingsAdapter
    {
        bool CanRead(string name);

        object Read(string name);

        void Write(string name, object value);
    }
}