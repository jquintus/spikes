namespace FunWithCastles.Settings
{
    public interface ISettingsBuilder
    {
        ISettingsBuilder Add(ISettingsAdapter adapter);

        ISettingsBuilder AddReadOnly(ISettingsAdapter adapter);

        TSettings Build<TSettings>() where TSettings : class;

        ISettingsBuilder Load(ISettingsLoader loader);
    }
}