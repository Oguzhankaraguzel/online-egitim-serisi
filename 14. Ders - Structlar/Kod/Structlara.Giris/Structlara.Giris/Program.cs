using Structlara.Giris.Sekiller;
using System;
using System.Drawing;

namespace Structlara.Giris
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            //Struct oluşturma ve kullanma örneği

            //Ogrenci ogrenci = new Ogrenci();
            //ogrenci._ad = "Ali";
            //ogrenci._numara = 12345;
            //ogrenci._sinif = "10A";
            //Console.WriteLine($"Öğrenci Adı: {ogrenci._ad}");
            //Console.WriteLine($"Öğrenci Numarası: {ogrenci._numara}");
            //Console.WriteLine($"Öğrenci Sınıfı: {ogrenci._sinif}");

            //Struct'ların hafızaki yerleşimi

            //Console.WriteLine($"{nameof(Nokta)} adlı struct'ın stack'taki boyutu: {sizeof(Nokta)} byte");
            //Nokta nokta = new Nokta();
            //nokta._y = 20;
            //nokta._x = 10;
            //Yazdır(nokta);
            //Console.WriteLine($"Nokta X: {nokta._x}, Y: {nokta._y}");
            //Console.ReadLine();

            ////new anahtar kelimesi ve ctor kullanımı
            //Nokta nokta = new Nokta(5,10); // her zaman parametresiz bir ctor vardır. (structlarda)
            //Console.WriteLine(nokta.Yazdir());

            ////ctor kullanmadan tüm alanlara değer atanarak kullanılabilir.
            //Nokta nokta2;
            //nokta2._y = 20; //Struct'lar default olarak 0 ile başlar, bu yüzden burada başlangıç değerlerini atıyoruz.
            //nokta2._x = 10; //Struct'lar default olarak 0 ile başlar, bu yüzden burada başlangıç değerlerini atıyoruz.

            //name space ve using direktifi.
            //using direktifi, kodun okunabilirliğini artırmak için kullanılır.
            //using Structlara.Giris.Sekiller;
            //using Structlara.Giris.Sekiller.Kare; //Bu şekilde de kullanılabilir.
            //Kase.cs dosaysında name space tanımını silerseniz. global name space'e ait olur ve bu şekilde kullanılabilir.
            //Kare kare = new Kare(new Nokta(0, 0), new Nokta(5, 5));
            //Console.WriteLine(kare.Yazdır());

            //ilkel veri tipleri struct olarak tanımlanmıştır. string özel durumdur.
            //int, float, double, char, bool gibi ilkel veri tipleri struct olarak tanımlanmıştır.

            //DateTime tarih = new DateTime(2023, 10, 1); //DateTime struct'ı kullanımı
            ////sıklıkla kullanılır.
            //Console.WriteLine($"Tarih: {tarih.ToShortDateString()}"); //ToShortDateString() metodu, tarihi kısa formatta döndürür.
            //Console.WriteLine($"Tarih: {tarih.ToString("dd:MM:yyyyy")}"); //ToShortDateString() metodu, tarihi kısa formatta döndürür.

            //TimeSpan zaman = new TimeSpan(2, 30, 0); //TimeSpan struct'ı kullanımı
            //Console.WriteLine(zaman.Hours);

            //DateTime dateTime = DateTime.Now; //DateTime.Now, geçerli tarihi ve saati döndürür.

            //TimeSpan aralik = tarih - dateTime;

            //Console.WriteLine($"Geçen süre: {aralik.TotalDays} gün, {aralik.Hours} saat, {aralik.Minutes} dakika, {aralik.Seconds} saniye");

            //Guid guid = Guid.NewGuid();
            //Console.WriteLine(guid.ToString());

        }
        public static void Yazdır(Nokta nokta)
        {
            nokta._x = 30; //Bu nokta değişkeni stack'te tutuluyor, bu yüzden bu değişiklik sadece bu metot içinde geçerli olacak.
            Console.WriteLine($"Nokta X: {nokta._x}, Y: {nokta._y}");
        }
    }
    
    public struct Ogrenci
    {
        //field'lar _camelCase ile yazılır
        public string _ad;
        public int _numara;
        public string _sinif;
    }
    public struct Nokta
    {
        public Nokta(int x,int y)
        {
            _x = x; //Struct'lar default olarak 0 ile başlar, bu yüzden burada başlangıç değerlerini atıyoruz.
            _y = y; //Struct'lar default olarak 0 ile başlar, bu yüzden burada başlangıç değerlerini atıyoruz.
        }
        public Nokta(int y)
        {
            _x = 0; //Struct'lar default olarak 0 ile başlar, bu yüzden burada başlangıç değerlerini atıyoruz.
            _y = y; //Struct'lar default olarak 0 ile başlar, bu yüzden burada başlangıç değerlerini atıyoruz.
        }
        public int _x; //en değersiz byte'ın adresi nokta adlı değişkenin sakladığı adres.
        public int _y;

        public string Yazdir()
        {
            return $"Nokta X: {_x}, Y: {_y}";
        }
    }
}