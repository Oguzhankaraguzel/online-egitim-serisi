using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrolYapilariVeAkisKontolu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool kosul1 = false;
            bool kosul2 = true;
            if (kosul1 && kosul2)
            {
                Console.WriteLine("if bloğu çalıştı");
            }
            else if (kosul1 && kosul2)
            {
                Console.WriteLine("1. else if bloğu çalıştı");
            }
            else if (kosul1)
            {
                Console.WriteLine("2. else if bloğu çalıştı");
            }
            else if (!kosul2)
            {
                Console.WriteLine("3. else if bloğu çalıştı");
            }
            else
            {
                Console.WriteLine("else bloğu çalıştı");
            }
        }
    }
}
