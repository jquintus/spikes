using System;
using System.IO;

namespace ExistentialFiles
{
    public class Program
    {
        public static void Main(string[] args)
        {


            if (File.Exists(@"c:\path\\\\\\\\\\file.txt"))
            {
                Console.WriteLine(@"File.Exists NO cares about \\");
            }
            else
            {
                Console.WriteLine(@"File.Exists cares about \\ !!!!!!!!!!!!!!!!");
            }
        }
    }
}