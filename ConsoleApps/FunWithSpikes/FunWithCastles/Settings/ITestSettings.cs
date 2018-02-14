using System;

namespace FunWithCastles.Settings
{
    public interface ITestSettings
    {
        DateTime Date { get; set; }
        string Name { get; set; }
        int TheAnswer { get; set; }
        TimeSpan TotalTime { get; set; }
    }
}