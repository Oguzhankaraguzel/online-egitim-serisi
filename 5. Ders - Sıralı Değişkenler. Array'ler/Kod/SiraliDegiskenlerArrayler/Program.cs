using System;

namespace SiraliDegiskenlerArrayler
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            //int sayi = new int();
            //Console.WriteLine(sayi);
            //int[] sayilar = new int[5];
            //sayilar[0] = 10;
            //sayilar[1] = 10;
            //sayilar[2] = 10;
            //sayilar[3] = 10;
            //sayilar[4] = 10;
            ////1. kural indeks her zaman 0 ile başlar.
            ////2. kural eleman sayısından fazla elemana ulaşamazsınız.

            //short[] shorts = new short[4];
            ////new anahtar kelimesinin bir görevi ilk değerlerin atanmasıdır.
            //Console.WriteLine(shorts[2]);

            //char[] myString = { 'S', 'E', 'L', 'A', 'M' };
            ////string aslında bir char[]'dir.
            //string selamlama = "SELAM";
            ////stringler char array olduğu için doğrudan diziymiş gibi davranıp elemanlara teker teker ulaşabilirsiniz.
            //Console.WriteLine(selamlama[2]);

            ////4 elemanın her birisi stringtir.
            ////stinrg aslında char array'dir.
            //string[] isimler = new string[4] { "Ahmet","Mehmet","Ayşe","Fatma" };
            //Console.WriteLine(isimler[0][4]);

            ////dağınık diziler sıralı değişkenlerden olşuan sıralı değişkenblerdir. Teorik olarak bir sınırı yoktur.
            //int[][] daginikDizi = new int[4][];
            //daginikDizi[0] = new int[4];
            //daginikDizi[0][2] = 10;

            //matrislerde satır ve sütun sayısı sabittir. jagged arrayler'de sabitlik yoktur.
            //int[,,,] matris = new int[1,1,1,1];

            //ikinci kısım.

            // Bir örnek array tanımlayalım
            byte[] data = { 72, 101, 108, 108, 111, 44, 32, 87, 111, 114, 108, 100, 33 }; // "Hello, World!"
            
            // Array'in başlangıç adresini sabitlemek için fixed kullanıyoruz
            fixed (byte* ptr = data)
            {
                Console.WriteLine("Array'in başlangıç adresi: {0:X}", (long)ptr);

                // Array'in her elemanının adresini ve değerini yazdıralım
                for (int i = 0; i < data.Length; i++)
                {
                    byte* currentAddress = ptr + i; // Elemanın gerçek adresi
                    Console.WriteLine($"Adres: {(long)currentAddress:X} | Değer: {*(currentAddress)} | Karakter: {(char)*(currentAddress)}");
                }
            }
            Console.Read();
        }
    }
}
