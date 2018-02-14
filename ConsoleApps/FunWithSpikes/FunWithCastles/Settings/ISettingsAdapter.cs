namespace FunWithCastles.Settings
{
    public interface ISettingsAdapter
    {
        bool TryRead(string name, out object value);

        bool TryWrite(string name, object value);
    }
}