using System.Collections.Generic;

namespace FunWithCastles.Settings.Loaders
{
    public interface ISettingsLoader
    {
        IDictionary<string, object> Load();
    }
}