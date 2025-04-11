using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodlar.Ucuncu.Bolum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ref anahtar kelimesi
            //int number = 5;
            //Console.WriteLine(KaresiniAl(ref number));
            //Console.WriteLine(number);

            //out kullanımı
            //Topla(5, 6, out int sonuc);
            //Console.WriteLine(sonuc);  

            //string metin = "a";
            //bool success = int.TryParse(metin, out int result);

            //if (success) Console.WriteLine(result);

            // in anahtar kelimesi
            //Yazdır("Büyük harf");

            // params anahtar kelimesi
            //int[] array = { 1, 2, 3, 4, 5 };
            //ToplamYazdir(array);
            //ToplamYazdir(1, 2, 3, 4, 5);
        }
        public static void ToplamYazdir(params int[] sayilar) 
        {
            int toplam = 0;

            foreach (int i in sayilar) toplam += i;

            Console.WriteLine(toplam);
        }
        public static void Yazdır(in string message) 
        {
            //message = message.Trim();
            string newMessage = message;
            Console.WriteLine(newMessage.ToLower());
        }
        public static void Topla(int a,int b, out int toplam) 
        {
            toplam = a+ b;
        }

        public static int AddOne(ref int number) 
        {
            return ++number;
        }
        public static int KaresiniAl(ref int sayi) 
        {
            sayi = sayi*sayi;
            return sayi;
        }
    }
}
