using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Enumlar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OyunSeviyeleri mevcutSeviye = OyunSeviyeleri.Normal;
            if (mevcutSeviye == OyunSeviyeleri.Kolay)
            {
                Console.WriteLine("Kolay mod");
            }
            else if (mevcutSeviye == OyunSeviyeleri.Normal)
            {
                Console.WriteLine("Normal mod");
            }
            else if (mevcutSeviye == OyunSeviyeleri.Zor)
            {
                Console.WriteLine("Zor mod");
            }
            else
            {
                Console.WriteLine("Hata");
            }

            Console.WriteLine("Mevcut seviye: " + (int)mevcutSeviye);

            foreach (var item in Enum.GetValues(typeof(Aylar)))
            {
                Console.WriteLine((int)item + ". Ay : " + item.ToString());
            }
        }
    }
    public enum OyunSeviyeleri : byte
    {
        Kolay = 1,
        Normal,
        Zor
    }
    public enum  Aylar
    {
        Ocak = 1,
        Subat,
        Mart,
        Nisan,
        Mayis,
        Haziran,
        Temmuz,
        Agustos,
        Eylul,
        Ekim,
        Kasim,
        Aralik
    }
}
