using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiraliDegiskenlerArrayler
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}


//// Bir örnek array tanımlayalım
//byte[] data = { 72, 101, 108, 108, 111, 44, 32, 87, 111, 114, 108, 100, 33 }; // "Hello, World!"

//// Array'in başlangıç adresini sabitlemek için fixed kullanıyoruz
//fixed (byte* ptr = data)
//{
//    Console.WriteLine("Array'in başlangıç adresi: {0:X}", (long)ptr);

//    // Array'in her elemanının adresini ve değerini yazdıralım
//    for (int i = 0; i < data.Length; i++)
//    {
//        byte* currentAddress = ptr + i; // Elemanın gerçek adresi
//        Console.WriteLine($"Adres: {(long)currentAddress:X} | Değer: {*(currentAddress)} | Karakter: {(char)*(currentAddress)}");
//    }
//}