using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz_Alg_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // kullanıcıdan bir sayı istenecek.
            // sayı kadar eleman konsola yazdırılacak.
            // ancak ekrana yazdılacak olan eleman 3'e bölünüyorsa Fizz, 5'e bölünüyorsa Buzz, 3 ve 5'e bölünüyorsa FizzBuzz yazılacak.
            // 3 ve 5'e bölünmeyen sayılar normal yazılacak.
            // sayı 1'den başlayacak ve kullanıcını verdiği sayı dahil olacak.

            Console.WriteLine("Lütfen bir sayı giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());

            string[] array = new string[sayi];

            #region alg
            for (int i = 1; i <= sayi; i++)
            {
                if ((i % 3) == 0 && (i % 5) == 0)
                    array[i - 1] = "FizzBuzz";
                
                else if ((i % 3) == 0)
                    array[i - 1] = "Fizz";
                
                else if ((i % 5) == 0)
                    array[i - 1] = "Buzz";
                
                else
                    array[i - 1] = i.ToString();
                
            }
            #endregion

            foreach (string item in array)
                Console.WriteLine(item);
            
        }
    }
}
