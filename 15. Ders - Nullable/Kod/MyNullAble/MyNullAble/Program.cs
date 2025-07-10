using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNullAble
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Lütfen Adınızı Giriniz");
            //string ad = Console.ReadLine();
            //Console.WriteLine("Lütfen Yaşınızı giriniz! (İsteğe bağlı! Boş Bırakabilirsiniz) ");
            //bool yagGirildi = int.TryParse(Console.ReadLine(), out int yas);
            //if (yagGirildi)
            //{
            //    Console.WriteLine("Kullanıcı Bilgisi: { Ad: " + ad + " } " + "{ Yas: " + yas + " }");
            //}
            //else
            //{
            //    Console.WriteLine("Kullanıcı Bilgisi: { Ad: " + ad + " } ");
            //}
            //Console.WriteLine("Yas Değişkeni değeri : " + yas);

            //Bütün değer tipleri. null alanilir. bool, int gibi tam sayılar. double gibi noktalı sayılar. char vs.
            //string özel durumdur. Class'lar doğası gereği null alabilir.

            //nullable bir değişkenin değerinin olup olmadığını kontrol etmek için HasValue özelliğini kullanabiliriz.
            //Console.WriteLine("Lütfen Adınızı Giriniz");
            //string ad = Console.ReadLine();
            //Console.WriteLine("Lütfen Yaşınızı giriniz! (İsteğe bağlı! Boş Bırakabilirsiniz) ");
            //bool yagGirildi = int.TryParse(Console.ReadLine(), out int yasGirdisi);
            //int? yas = null; 
            //if (yagGirildi)
            //{
            //    yas = yasGirdisi; 
            //}

            //if (yas.HasValue)
            //{
            //    Console.WriteLine("Kullanıcı Bilgisi: { Ad: " + ad + " } " + "{ Yas: " + yas.Value + " }");
            //}
            //else
            //{
            //    Console.WriteLine("Kullanıcı Bilgisi: { Ad: " + ad + " } ");
            //}

            //programıma en az 18 yaşındaki kişi kayıt olabilir. Eğer yaş girilmemişse kullanıcı en az 18 yaşında olarak kabul edilir.
            //getvalueordefault metodu eğer değer null ise default değerini alır. int için 0, bool için false, string için null gibi.
            //Eğer istenirse default değerini değiştirebiliriz.
            //Console.WriteLine("Lütfen Adınızı Giriniz");
            //string ad = Console.ReadLine();
            //Console.WriteLine("Lütfen Yaşınızı giriniz! (İsteğe bağlı! Boş Bırakabilirsiniz) ");
            //bool yagGirildi = int.TryParse(Console.ReadLine(), out int yasGirdisi);
            //int? yas = null;
            //if (yagGirildi) // normalde bu kontrole gerek kalmadı.
            //{
            //    yas = yasGirdisi;
            //}
            //Console.WriteLine("Kullanıcı Bilgisi: { Ad: " + ad + " } " + "{ Yas: " + yas.GetValueOrDefault(18) + " }");

            //Null coalescing operator (??) kullanarak null değerini kontrol edebiliriz.
            //Eğer değer null ise sağdaki değeri alır. Eğer değer null değilse soldaki değeri alır.
            //Console.WriteLine("Lütfen Adınızı Giriniz");
            //string ad = Console.ReadLine();
            //Console.WriteLine("Lütfen Yaşınızı giriniz! (İsteğe bağlı! Boş Bırakabilirsiniz) ");
            //bool yagGirildi = int.TryParse(Console.ReadLine(), out int yasGirdisi);
            //int? yas = null;
            //if (yagGirildi)
            //{
            //    yas = yasGirdisi;
            //}
            //Console.WriteLine("Kullanıcı Bilgisi: { Ad: " + ad + " } " + "{ Yas: " + (yas ?? default) + " }");

            //Null conditional operator (?.) kullanarak null değerini kontrol edebiliriz.
            //Console.WriteLine("Lütfen Adınızı Giriniz");
            //Console.ReadLine();
            //string ad = null;
            //int? karakterSayisi = ad?.Length; 
            //Console.WriteLine($"Adınız {karakterSayisi ?? 0} karakterden oluşuyor");

            //Null conditional operator (?.) ve null coalescing operator (??) birlikte kullanarak null değerini kontrol edebiliriz.
            //Console.WriteLine("Lütfen Adınızı Giriniz");
            //Console.ReadLine();
            //string ad = null;
            //int karakterSayisi = ad?.Length ?? 0;
            //Console.WriteLine($"Adınız {karakterSayisi} karakterden oluşuyor");

            // ? değişken tipine eklenirse değişekenin null alabileceğini belirtir.
            // ?. Length özelliği null ise null döner. Eğer null değilse Length özelliğini alır.
            // ?? operatörü ise eğer sol taraf null ise sağ tarafı alır. Eğer sol taraf null değilse sol tarafı alır.

            //Nullable<int> sayi = 50;//new Nullable<int>(50); // int? kullanımı ile birebir aynıdır. hatta int? == Nullable<int>'dir

            MyNullable<int> sayi = new MyNullable<int>(50);
            if (sayi.HasValue)
            {
                Console.WriteLine("Sayı mevcut: " + sayi.Value);
            }
            else
            {
                Console.WriteLine("Sayı mevcut değil. Varsayılan Değer = " + sayi.GetValueOrDefault() );
            }
        }
    }
}
