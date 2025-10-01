using System;

namespace swissknife.Services.Extensions
{
    public struct ConsoleEx
    {
        public static void Pause()
        {
            Console.WriteLine("\nDevam Etmek İçin Bir Tuşa Basın...");
            Console.ReadKey();
        }
    }
}
