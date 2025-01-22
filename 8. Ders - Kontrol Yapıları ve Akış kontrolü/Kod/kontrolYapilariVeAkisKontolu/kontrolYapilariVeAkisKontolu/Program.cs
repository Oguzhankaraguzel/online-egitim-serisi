using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kontrolYapilariVeAkisKontolu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // if yapısı
            bool kosul1 = false;
            bool kosul2 = true;
            //if (kosul2 == true) // boşuna işlem.
            //{
            //    Console.WriteLine("if bloğu çalıştı");
            //}

            //istenilen kadar else if eklenebilir.
            // eğer if koşulu doğru ise if çalışır.
            // eğer if yanlış ise ilk true koşula sahip else if çalışır. gerisi çalışmaz.
            //hepsi yanlış ise else çalışır.
            //int a = 5;
            //int b = 10;
            //if (a == b) // karşılaştırma operatörleride kullanılır.
            //{
            //    Console.WriteLine("if bloğu çalıştı");
            //}
            //else if (a < b)
            //{
            //    Console.WriteLine("1. else if bloğu çalıştı");
            //}
            //else if (a != b)
            //{
            //    Console.WriteLine("2. else if bloğu çalıştı");
            //}
            //else
            //{
            //    Console.WriteLine("else bloğu çalıştı");
            //}

            int a = 5;
            int b = 10;
            //if (a == b) // karşılaştırma operatörleride kullanılır.
            //{
            //    Console.WriteLine("1 if bloğu çalıştı");
            //}
            //else if (a < b)
            //{
            //    Console.WriteLine("1. else if bloğu çalıştı");
            //}

            //if (false)
            //{
            //    Console.WriteLine("2. if bloğu çalıştı");
            //}
            //else if (a != b)
            //{
            //    Console.WriteLine("2. else if bloğu çalıştı");
            //}
            //else
            //{
            //    Console.WriteLine("else bloğu çalıştı");
            //}

            // kontrol yapıları if ile başlamak zorundadır.
            // else ya da el if zorunlu değildir.
            // eğer if çalışmaz ise ilk true'ya sahip else if çalışır. diğerleri çalışmaz.
            //if (a < b)
            //{
            //    Console.WriteLine($"a değeri b'den küçütür");
            //}
            //if (b < 20)
            //{
            //    Console.WriteLine($"b değeri 20'den küçütür");
            //}

            // tek satır kullanım.
            //if (a < b) 
            //    Console.WriteLine($"a değeri b'den küçütür");

            // ternary if kullanımı;
            // int c = a > b ? 75 : 100;
            // int c = !kosul1 ? 75 : 100;
            // Console.WriteLine(c);
            //Console.WriteLine("Lütfen gün numarasını giriniz: ");
            //int dayNumber = Convert.ToInt32(Console.ReadLine());

            //switch (dayNumber)
            //{
            //    case 1:
            //        Console.WriteLine("Pazartesi");
            //        break;
            //    case 2:
            //        Console.WriteLine("Salı");
            //        break;
            //    case 3:
            //        Console.WriteLine("Çarşamba");
            //        break;
            //    case 4:
            //        Console.WriteLine("Perşembe");
            //        break;
            //    case 5:
            //        Console.WriteLine("Cuma");
            //        break;
            //    case 6:
            //        Console.WriteLine("Cumartesi");
            //        break;
            //    case 7:
            //        Console.WriteLine("Pazar");
            //        break;
            //    default:
            //        Console.WriteLine("Lütfen 1 ila 7 arasında bir değer giriniz");
            //        break;
            //}

            // akış kontrolü

            //int i = 0;

            //break; // bir döngüyü ya da switch-case yapısını sonlandırır.
            //return; // bir döngüyü ya da switch-case yapısını sonlandırır. Metodların akışını durdurur. istenirse metodlar ile geriye değer döndürür.
            //continue; // belirli bir koşulda döngüyü sonlandırır ve döngünün başına döner.
            //goto; // daha önceden işaretlenen adıma gitmenizi sağlar. genellikle kullanılmaz. kodun okunabilirliğini bozar.
            //throw; // hata fırlatır. hata fırlatıldığı yerde durur. hata fırlatıldığı yerdeki kodlar çalışmaz.

            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i == 5) break;

            //    Console.WriteLine(i);
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i == 5) return;

            //    Console.WriteLine(i);
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i == 5) continue;

            //    Console.WriteLine(i);
            //}

            //for (int i = 1; i <= 10; i++)
            //{
            //    if (i == 5) throw new Exception("hata fırlatıldı");

            //    Console.WriteLine(i);
            //}


        //    int i = 0;
        //git:
        //    if (i < 5)
        //    {
        //        i++;
        //        Console.WriteLine(i);
        //        goto git;
        //    }



            Console.ReadLine();
        }
    }
}
