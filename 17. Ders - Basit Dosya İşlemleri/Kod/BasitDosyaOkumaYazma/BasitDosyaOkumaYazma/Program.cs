using System;
using System.IO;

namespace BasitDosyaOkumaYazma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string icerik = Console.ReadLine();
            ////string dosyaAdi = "ornek"; // Dosya adı uzantısı olmadan yazılmıştır.
            //// Bu durumda dosya açılması için işletim sistemi tarafından varsayılan olarak bir program atanmayacaktır.
            //string dosyaAdi = "ornek2.txt"; // Dosya adı uzantısı ile
            //File.WriteAllText(dosyaAdi, icerik); //WriteAllText metodu, dosya oluşturur ve içeriği yazar.
            ////Eğer dosya zaten varsa, içeriği siler ve yeni içeriği yazar.

            //Console.WriteLine("Ekleme Yapmak ister misiniz? (E/H)");
            //if (Console.ReadLine() == "E")
            //{
            //    string ekleme = Console.ReadLine();
            //    // AppendAllText metodu, dosyaya ekleme yapar. Eğer dosya yoksa oluşturur.
            //    File.AppendAllText(dosyaAdi, ekleme);
            //}

            //// Dosyayı okumak için ReadAllText metodunu kullanıyoruz.
            //string dosyaIcerigi = File.ReadAllText(dosyaAdi);
            //Console.WriteLine("Dosya içeriği:");
            //Console.WriteLine(dosyaIcerigi);
            //// Real All text ile dosya içeriği okunur ve ekrana yazdırılır.
            //// Ancak dosya yoksa hata fırlatır.
            //// hatayı öncelemek için exists metodunu kullanabiliriz.
            //if (File.Exists(dosyaAdi)) // dosya mvarlığı kontrol edilir.
            //{
            //    Console.WriteLine("Dosya başarıyla okundu.");
            //    //string dosyaIcerigi = File.ReadAllText(dosyaAdi);
            //}
            //else
            //{
            //    Console.WriteLine("Dosya bulunamadı.");
            //}
            
            string dosyaAdi = "ornek3.txt";
            string klasorAdi = "ornekKlasoru";
            string icerik = "Bu bir deneme içeriğidir.";
            // Klasör oluşturma
            if (!Directory.Exists(klasorAdi))
            {
                Directory.CreateDirectory(klasorAdi);
                Console.WriteLine($"{klasorAdi} klasörü oluşturuldu.");
            }
            else
            {
                Console.WriteLine($"{klasorAdi} klasörü zaten var.");
            }
            // Dosya yolu oluşturma
            string dosyaYolu = Path.Combine(klasorAdi, dosyaAdi); // ornekKlasoru\ornek3.txt
            // Göreli dosya yolu nedir? ne işe yarar?
            // PAth.Combine metodu, klasör ve dosya adını birleştirerek tam dosya yolunu oluşturur.
            // Alternatif olarak, manuel olarak da yazılabilir:
            //Ancak path bu durum daha iyi yönetir.
            //string dosyaYolu2 = @"ornekKlasoru\ornek3.txt";
            // linux işeltim sistemlerinde ise dosya yolları // ornekKlasoru/ornek3.txt şeklinde yazılır.
            // Dosyaya yazma
            try
            {
                File.WriteAllText(dosyaYolu, icerik);
                Console.WriteLine($"{dosyaAdi} dosyasına yazıldı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dosyaya yazma hatası: {ex.Message}");
            }
            // Dosyayı okuma
            try
            {
                if (File.Exists(dosyaYolu))
                {
                    string dosyaIcerigi = File.ReadAllText(dosyaYolu);
                    Console.WriteLine($"{dosyaAdi} dosyasının içeriği:");
                    Console.WriteLine(dosyaIcerigi);
                }
                else
                {
                    Console.WriteLine($"{dosyaAdi} dosyası bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Dosyayı okuma hatası: {ex.Message}");
            }
            // Ödev = alt yarine dosyanın bir üst klasörüne gidin ve orada dosay oluşturun.
            // uygulamanızı debug içerisinde çalıştırın ama relase içeirine dosya ouşturun.
            // C'nin hemen altına dosyanızı oluşturun. 
    }
}
