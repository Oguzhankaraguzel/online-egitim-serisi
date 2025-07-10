using System;
using System.Globalization;

namespace tcf
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Kullanıcıdan yaşını alalım. eğer yaş yanlış girilmişse kullanıcıyı bilgilendirelim.
            //Console.WriteLine("Lütfen yaşınızı giriniz: ");
            //int yas = int.Parse(Console.ReadLine()); // hata tam olarak burada oluşuyor.
            //Console.WriteLine("Yaşınız: " + yas);
            
            bool isValidInput = false;
            do
            {
                try
                {
                    Console.WriteLine("Lütfen yaşınızı giriniz: ");
                    int yas = int.Parse(Console.ReadLine()); // hata tam olarak burada oluşuyor.
                    if (yas < 0 || yas > 120)
                    {
                        //bu gibi durumlarda exceptiın fırlatmak doğru değildir. Kullanıcıya hata mesajını doğrudan döndürmek ve kullanıcını hatayı yönetmesi beklemek en iyi çözümdür. 
                        //Exception'lar pahalıdır ve programınızı baya yorar.
                        throw new OverflowException("Yaş 0 ile 120 arasında olmalıdır.");
                    }
                    //int test = 5 / int.Parse(Console.ReadLine()); //divided by zero test için yorum satırı açılabilir.
                    Console.WriteLine("Yaşınız: " + yas);
                    isValidInput = true;
                }
                catch (FormatException ex)
                {
                    // FormatException, kullanıcı yanlış bir format girdiğinde oluşur.
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                catch (OverflowException ex)
                {
                    // OverflowException, kullanıcı çok büyük veya çok küçük bir sayı girdiğinde oluşur.
                    Console.WriteLine("Lütfen 0 ile 120 arasında bir yaş giriniz.");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                catch (DivideByZeroException ex)
                {
                    // ArgumentNullException, kullanıcı boş bir giriş yaptığında oluşur.
                    Console.WriteLine("Hatalı Bölme İşlemi");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                catch (Exception ex)
                {
                    // Beklenmeyen bir hata oluştuğunda bu blok çalışır.
                    throw;
                    // genelikle buradaki hata loglanır ve sisteme bildirilir. Kullanıcıya genel bir hata mesajı gösterilir.
                }
                finally
                {
                    //finally bloğu her durumda çalışır, hata olsa da olmasa da.
                    Console.WriteLine("Hata yönetimi tamamlandı.");
                    //Genellikler kaynak yönetimi ve temizliği yapılır.
                    //Örneğin, dosya kapatma, veritabanı bağlantısını kapatma gibi işlemler burada yapılır.
                }
            } while (!isValidInput);
        }
    }
}
