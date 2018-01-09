using System;

namespace FunWithCastles
{
    public interface ISettings
    {
        int MaxItems { get; set; }
        string Name { get; set; }

        DateTime LastModified { get; set; }
    }
}