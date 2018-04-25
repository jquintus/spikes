using System;

namespace FunWithCastles.Settings.Tests
{
    public class DefaultTestSettings : ITestSettings
    {
        public DateTime Date { get; set; } = new DateTime(2018, 1, 31);
        public string Name { get; set; } = "Doug";
        public int TheAnswer { get; set; } = 42;
        public TimeSpan TotalTime { get; set; } = TimeSpan.FromSeconds(55);
    }
}