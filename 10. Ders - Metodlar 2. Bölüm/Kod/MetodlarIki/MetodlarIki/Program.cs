using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodlarIki
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Please enter the first number: ");
            //int ilkSayi = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Please enter the second number: ");
            //int ikinciSayi = Convert.ToInt32(Console.ReadLine());
            //int toplam = 0;
            //toplam = SumTwoNumbers(ilkSayi, secondNumber: ikinciSayi);
            //Console.WriteLine("The sum of the two numbers is: " + toplam);


            //local değişken ve global değpişken farkları;

            void Topla(int sayiBir, int sayiIki)
            {
                int toplam = sayiBir + sayiIki; //local değişken
                Console.WriteLine($"metod içerisinde hesaplanan Girilen iki sayının toplamı: {toplam}");
            }
            int ilkSayi = 5;
            int ikinciSayi = 10;
            Topla(ilkSayi, ikinciSayi);
            Console.WriteLine($"metod dışında hesaplanan Girilen iki sayının toplamı: {toplam}");

            Console.ReadLine();
        }
        /// <summary>
        /// This method takes two numbers and returns the sum of them.
        /// </summary>
        /// <param name="firstNumber">first number</param>
        /// <param name="secondNumber">second number, cannot negative</param>
        /// <returns>firstNumber + secondNumber</returns>
        static int SumTwoNumbers(int firstNumber, int secondNumber)
        {
            int sum = firstNumber + secondNumber;
            return sum;
        }

    }
}
