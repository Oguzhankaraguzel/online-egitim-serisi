using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DegiskenlerVeOperatorler
{
    internal class Program
    {
        unsafe static void Main(string[] args)
        {
            int sayi = 7755987; // Örnek sayı
            string binarySayi = Convert.ToString(sayi, 2).PadLeft(32, '0');
            string formattedBinarySayi = InsertSpaceEvery8Bits(binarySayi);
            Console.WriteLine("Sayı: " + sayi);
            Console.WriteLine("Sayı (Binary): " + binarySayi);
            Console.WriteLine("Formatlanmış Sayı (Binary): " + formattedBinarySayi);
            // 'sayi' değişkeninin adresini alıyoruz
            int* ptr = &sayi;

            // 'bytePtr' adında bir byte işaretçisi oluşturuyoruz
            byte* bytePtr = (byte*)ptr;

            // Bellek düzenini belirlemek için bir değişken
            bool isLittleEndian = BitConverter.IsLittleEndian;
            Console.WriteLine("Bellek Düzeni: " + (isLittleEndian ? "Little-Endian" : "Big-Endian"));
            Console.WriteLine();

            //sayi adresi byte olarak elde et ekrana ikilik tabanda yazdır. sayinin ilk 8 hanesi ile karşılaştır.
            //sayi adresi + 1 byte olarak elde et ekrana ikilik tabanda yazdır. sayinin 9 il 16. hanesi ile karşılaştır.
            //sayi adresi + 2 byte olarak elde et ekrana ikilik tabanda yazdır. sayinin ilk 17 24 hanesi ile karşılaştır.
            //sayi adresi + 3 byte olarak elde et ekrana ikilik tabanda yazdır. sayinin ilk 25 32 hanesi ile karşılaştır.

            // Her bir byte'ı okuyup yazdırıyoruz
            for (int i = 0; i < sizeof(int); i++)
            {
                // Byte'ın bellek adresi
                byte* currentBytePtr = bytePtr + i;

                // Byte'ın değeri
                byte currentByte = *currentBytePtr;

                // Byte'ın onluk ve onaltılık değeri
                Console.WriteLine($"Byte {i + 1}: {currentByte} (Decimal), 0x{currentByte:X2} (Hex), Adres: 0x{(ulong)currentBytePtr:X})");

                // Byte'ın binary gösterimi
                string byteBinary = Convert.ToString(currentByte, 2).PadLeft(8, '0');
                Console.WriteLine($"Byte {i + 1} (Binary): {byteBinary}");

                // Orijinal sayının ilgili bitlerini alıyoruz
                int bitStartIndex = isLittleEndian ? (i * 8) : ((sizeof(int) - 1 - i) * 8);
                string originalBits = binarySayi.Substring(32 - bitStartIndex - 8, 8);
                Console.WriteLine($"Bitler {bitStartIndex}-{bitStartIndex + 7}: {originalBits}");

                // Karşılaştırma
                bool bitsEqual = originalBits == byteBinary;
                Console.WriteLine("Eşleşme: " + (bitsEqual ? "Evet" : "Hayır"));
                Console.WriteLine();
            }
            Console.ReadLine();
        }
        public static string InsertSpaceEvery8Bits(string binaryString)
        {
            int chunkSize = 8;
            int stringLength = binaryString.Length;
            string result = "";

            for (int i = 0; i < stringLength; i += chunkSize)
            {
                if (i + chunkSize > stringLength)
                    chunkSize = stringLength - i;

                result += binaryString.Substring(i, chunkSize) + " ";
            }

            return result.TrimEnd();
        }
    }
}
