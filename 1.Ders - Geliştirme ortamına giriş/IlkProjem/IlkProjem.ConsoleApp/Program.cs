using System;

namespace IlkProjem.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            int sayi = 10;
            Yazdir(in sayi);
        }

        static void Yazdir(in int deger)
        {
            Console.WriteLine("Sayı: " + deger);
            deger = 20; // HATA! `in` ile değiştirilemez.
        }

    }
}