using System;
using Humanizer;

namespace Repack
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Usage:   repack [date]");
            Console.WriteLine("Prints how long it is until your birthday.");
            Console.WriteLine("If you don't supply your birthday, it uses mine.");

            DateTime birthDay = GetBirthday(args);
            Console.WriteLine();

            var span = GetSpan(birthDay);

            Console.WriteLine("{0} until your birthday", span.Humanize());
        }

        private static TimeSpan GetSpan(DateTime birthDay)
        {
            if (birthDay < DateTime.Now)
            {
                if (birthDay.Year < DateTime.Now.Year)
                {
                    return GetSpan(new DateTime(DateTime.Now.Year, birthDay.Month, birthDay.Day));
                }
                else
                {
                    return GetSpan(new DateTime(DateTime.Now.Year + 1, birthDay.Month, birthDay.Day));
                }
            }
            var span = birthDay - DateTime.Now;
            return span;
        }

        private static DateTime GetBirthday(string[] args)
        {
            string day = null;
            if (args != null && args.Length > 0)
            {
                day = args[0];
            }

            return GetBirthday(day);
        }

        private static DateTime GetBirthday(string day)
        {
            DateTime parsed;
            if (DateTime.TryParse(day, out parsed))
            {
                return parsed;
            }
            else
            {
                return new DateTime(DateTime.Now.Year, 8, 20);
            }
        }
    }
}