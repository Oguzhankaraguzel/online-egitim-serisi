using System;
using System.Linq;

namespace İlkProgramVeStringManipulasyonu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lütfen Adınızı Giriniz");
            string isim = Console.ReadLine();
            Console.WriteLine($"Merhaba, {isim}! Programlama dünyasına hoş geldin.\nBugün seninle string manipülasyonu öğreneceğiz, Hazır mısın {isim}?\nTers çevrilmiş isminiz: {new string(isim.ToCharArray()
                                                                     .Reverse()
                                                                     .ToArray())}");
            Console.Read();
        }
    }
}
//Console.WriteLine("Lütfen Adınızı Giriniz");
//string isim = Console.ReadLine();
//Console.WriteLine("Merhaba, " + isim + "! Programlama dünyasına hoş geldin.");
//Console.WriteLine($"Bugün seninle string manipülasyonu öğreneceğiz, Hazır mısın {isim}?");

//char[] karakterler = isim.ToCharArray();
//Array.Reverse(karakterler);
//string tersIsim = new string(karakterler);
//Console.WriteLine($"Ters çevrilmiş isminiz: {tersIsim}");

//Console.Read();
