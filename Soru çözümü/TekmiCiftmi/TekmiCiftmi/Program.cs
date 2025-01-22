using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekmiCiftmi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bir sayı giriniz: ");
            int sayi = Convert.ToInt32(Console.ReadLine());

            //int bitSayi = 0b_0100; // eğer bir sayının ilk biti 1 ise tek 0 ise çifttir.
            // & işlemi ile sayının ilk bitini kontrol edebiliriz. & işlemi sayıları bit basında ve işlemine sokar.
            // örnek olarak 5 & 4 = 101 & 100 = 100 = 4
            // peki ben her sayıyı 1 ile and işlemine sokarsam ne olur?
            // 5 & 1 = 101 & 001 = 001 = 1
            // 4 & 1 = 100 & 001 = 000 = 0


            if (sayi % 2 == 0)
            {
                Console.WriteLine("Girdiğiniz sayı çifttir.");
            }
            else
            {
                Console.WriteLine("Girdiğiniz sayı tektir.");
            }

            Console.WriteLine("Bit bazında kontrol: ");

            if ((sayi & 1) == 0)
            {
                Console.WriteLine("Girdiğiniz sayı çifttir.");
            }
            else
            {
                Console.WriteLine("Girdiğiniz sayı tektir.");
            }
        }
    }
}
