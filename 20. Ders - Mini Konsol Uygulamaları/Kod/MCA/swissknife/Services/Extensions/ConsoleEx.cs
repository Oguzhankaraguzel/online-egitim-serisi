using System;
using System.Text;

namespace swissknife.Services.Extensions
{
    public struct ConsoleEx
    {
        /// <summary>
        /// Console ekranını duraklatır ve kullanıcıdan bir tuşa basmasını bekler.
        /// </summary>
        public static void Pause()
        {
            Console.WriteLine("\nDevam Etmek İçin Bir Tuşa Basın...");
            Console.ReadKey();
        }

        /// <summary>
        /// Kullanıcıdan çok satırlı metin girişi alır.
        /// </summary>
        /// <param name="info">başlık olarak gösterilmek istenilen bilgi</param>
        /// <returns>Kullanıcını girdisini string olarak döndürür</returns>
        public static string ReadMultiLine(string info,string content = null)
        {
            StringBuilder sb = new StringBuilder(content);
            // Burada bir sonsuz döngü başlatıyoruz
            // string builde'ı doldurup geri döndürüyoruz
            while (true)
            {
                // Todo: Buradaki algorritma çok kötü durumda.
                // Performans sorunları olabilir.
                // Performansını artırmak için farklı bir yöntem geliştirilebilir.
                // Bonus: Yön tuşları ile imleç kontrolü eklenebilir.
                Console.Clear();

                if (!string.IsNullOrEmpty(info))
                {
                    Console.WriteLine(info);
                }

                Console.WriteLine("ESC Bitir, ENTER Satır Atla \n");
                Console.Write(sb.ToString());

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    break;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    sb.AppendLine();
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                {
                    sb.Length--;

                    if(sb.Length > 0 && sb[sb.Length - 1] == '\r')
                        sb.Length--;
                }
                else if (char.IsLetter(keyInfo.KeyChar) || char.IsDigit(keyInfo.KeyChar) || keyInfo.Key == ConsoleKey.Spacebar || keyInfo.Key == ConsoleKey.Tab)
                {
                    sb.Append(keyInfo.KeyChar);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Kullanıcı Çıkış işlemini Onaylar
        /// </summary>
        /// <returns>Kullanıcı çıkmak istiyorsa true, istemiyorsa false döndürür.</returns>
        public static bool ConfirmExit()
        {
            Console.Clear();
        ConfirmExit:
            Console.WriteLine("Çıkmak istediğinize emin misiniz? (E/H)");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.E)
            {
                return true;
            }
            else if (key == ConsoleKey.H)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen Tekrar Deneyiniz");
                goto ConfirmExit;
            }
        }
    }
}
