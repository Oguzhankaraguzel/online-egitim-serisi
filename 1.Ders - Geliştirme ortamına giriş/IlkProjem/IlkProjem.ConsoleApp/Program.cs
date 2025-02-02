using System;

namespace IlkProjem.ConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("enter the first number:");
            string firstınput = Console.ReadLine();

            Console.WriteLine("enter the second number:");
            string secondınput = Console.ReadLine();

            int firstnumber = Convert.ToInt32(firstınput);
            int secondnumber = Convert.ToInt32(secondınput);

            int sum = AddTwoNumbers(firstnumber, secondnumber);

            Console.WriteLine($"Answer: {sum}");
            Console.ReadLine();
        }
        /// <summary>
        /// prompts the user to enter two numbers, calculates their sum, and displays the result.
        /// </summary>
        static int AddTwoNumbers(int firstNum, int secondNum)
        {
            int sum = firstNum + secondNum;
            return sum;
        }
    }
}