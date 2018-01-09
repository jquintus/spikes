using System;

namespace FunWithCastles
{
    public interface IAppSettings
    {
        DateTime LastModified { get; set; }
        int MaxItems { get; set; }
        string Name { get; set; }
    }
}