using System;

namespace IlkProjem.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Sınav notunu giriniz: ");
            int not = int.Parse(Console.ReadLine());

            // Notun geçerli aralıkta olup olmadığını kontrol et
            string mesaj = (not >= 0 && not <= 100)
                ? (not >= 90 ? "Harf Notu: A"
                    : not >= 80 ? "Harf Notu: B"
                    : not >= 70 ? "Harf Notu: C"
                    : not >= 60 ? "Harf Notu: D"
                    : not >= 50 ? "Harf Notu: E"
                    : "Harf Notu: F (Kaldı)")
                : "Geçersiz bir not girdiniz. Lütfen 0 ile 100 arasında bir değer giriniz.";

            Console.WriteLine(mesaj);
        }
    }
}