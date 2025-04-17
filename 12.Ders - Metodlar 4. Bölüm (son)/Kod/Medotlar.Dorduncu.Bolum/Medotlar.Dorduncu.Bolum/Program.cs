using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medotlar.Dorduncu.Bolum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // method overload ve local function
            //string name = "   oĞuzhan    ";
            //string surName = "   karagüzel    ";
            //Console.WriteLine(FormatName(name, surName));

            //void Greetings() 
            //{
            //    string formattedName = FormatName(name, surName);
            //    Console.WriteLine("Hello " + formattedName);
            //}
            //Greetings();
            //Greetings();
            //Greetings();
            //Greetings();
            //Greetings();

            // expression bodied method
            //Console.WriteLine(Sum(-1, -2));

            string userName = "oguz25!";
            userName = ClearNumber(userName);
            Console.WriteLine(userName);

        }

        public static string ClearNumber(string userName)
        {
            if (string.IsNullOrEmpty(userName))
                return string.Empty;

            char firstChar = userName[0];
            string rest = userName.Substring(1);

            return (char.IsNumber(firstChar) ? "" : firstChar.ToString()) + ClearNumber(rest);
        }

        public static int Sum(int a, int b) => a + b < 0 ? -1 : a + b;

        //public static string FormatName(string name) 
        //{
        //    name = name.Trim().ToLower();
        //    return char.ToUpper(name[0]) + name.Substring(1);
        //}

        //public static string FormatName(string name, string surName)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append(FormatName(name));
        //    sb.Append(' ');
        //    sb.Append(surName.Trim().ToUpper());
        //    return sb.ToString();
        //}
    }
}
