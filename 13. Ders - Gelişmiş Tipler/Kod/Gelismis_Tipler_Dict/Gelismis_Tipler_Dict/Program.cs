using System;
using System.Collections.Generic;

namespace Gelismis_Tipler_Dict
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> yaslar = new Dictionary<string, int>()
            {
                {"Oğuzhan",30 },
                {"Ahmet",30 },
                {"Veli", 30 }
            };
            yaslar["Ayşe"] = 20; /*Anahtar yoksa oluşturulur ve değer atanır*/
            yaslar["Ayşe"] = 20; /*Anahtar varsa değeri güncellenir*/
            //yaslar.Add("Ayşe",25); /*Burada hata vermesinin sebebi. aynı anahtarı tekrar eklemeye çalışmasıdır*/
            yaslar.Remove("Oğuzhan");
            if (yaslar.ContainsKey("Oğuzhan"))
            {
                Console.WriteLine(yaslar["Oğuzhan"]);
            }
            foreach (var item in yaslar)
            {
                if (item.Value == 30)
                {
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
            }
        }
    }
}
