using System;

namespace IlkProjem.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            SelamVer(); // 1. Metot çağrısı
            SelamVer(); // 2. Metot çağrısı
            SelamVer(); // 3. Metot çağrısı
        }
        public static void SelamVer() // Metot tanımlama
        {
            Console.WriteLine("Merhaba! Bu bir metot çağrısıdır."); // Metot içeriği
        }
    }
}