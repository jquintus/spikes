namespace FunWithCastles.Settings
{
    public interface ISettingsBuilder
    {
        ISettingsBuilder Add(ISettingsAdapter adapter, ISettingConverter converter = null);

        ISettingsBuilder AddReadOnly(ISettingsAdapter adapter, ISettingConverter converter = null);

        TSettings Build<TSettings>() where TSettings : class;

        ISettingsBuilder Load(ISettingsLoader loader, ISettingConverter converter = null);
    }
}