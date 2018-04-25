using System.Collections.Generic;

namespace FunWithCastles.Settings
{
    public interface ISettingsLoader
    {
        IDictionary<string, object> Load();
    }
}