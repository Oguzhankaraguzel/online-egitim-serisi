using System;
using System.Runtime.CompilerServices;

namespace IlkProjem.ConsoleApp
{
    unsafe internal class UnsafeCode
    {
        unsafe public static void PrintByteArrayElementsWithAddresses()
        {
            // Bir örnek array tanımlayalım
            byte[] data = { 72, 101, 108, 108, 111, 44, 32, 87, 111, 114, 108, 100, 33 }; // "Hello, World!"

            // Array'in başlangıç adresini sabitlemek için fixed kullanıyoruz
            fixed (byte* ptr = data)
            {
                Console.WriteLine("Array'in başlangıç adresi: {0:X}", (long)ptr);

                // Array'in her elemanının adresini ve değerini yazdıralım
                for (int i = 0; i < data.Length; i++)
                {
                    byte* currentAddress = ptr + i; // Elemanın gerçek adresi
                    Console.WriteLine($"Adres: {(long)currentAddress:X} | Değer: {*(currentAddress)} | Karakter: {(char)*(currentAddress)}");
                }
            }
        }

        unsafe public static void AnalyzeIntegerBytesAndBits()
        {
            int sayi = 1273; // Örnek sayı
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
        }

        unsafe public static void PrintVariableTypeSizesInBytesAndBits()
        {
            Console.WriteLine($"bool    : {Unsafe.SizeOf<bool>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<bool>() * 8} bit değere eşittir.");
            Console.WriteLine($"byte    : {Unsafe.SizeOf<byte>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<byte>() * 8} bit değere eşittir.");
            Console.WriteLine($"sbyte   : {Unsafe.SizeOf<sbyte>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<sbyte>() * 8} bit değere eşittir.");
            Console.WriteLine($"char    : {Unsafe.SizeOf<char>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<char>() * 8} bit değere eşittir.");
            Console.WriteLine($"short   : {Unsafe.SizeOf<short>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<short>() * 8} bit değere eşittir.");
            Console.WriteLine($"ushort  : {Unsafe.SizeOf<ushort>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<ushort>() * 8} bit değere eşittir.");
            Console.WriteLine($"int     : {Unsafe.SizeOf<int>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<int>() * 8} bit değere eşittir.");
            Console.WriteLine($"uint    : {Unsafe.SizeOf<uint>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<uint>() * 8} bit değere eşittir.");
            Console.WriteLine($"long    : {Unsafe.SizeOf<long>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<long>() * 8} bit değere eşittir.");
            Console.WriteLine($"ulong   : {Unsafe.SizeOf<ulong>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<ulong>() * 8} bit değere eşittir.");
            Console.WriteLine($"float   : {Unsafe.SizeOf<float>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<float>() * 8} bit değere eşittir.");
            Console.WriteLine($"double  : {Unsafe.SizeOf<double>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<double>() * 8} bit değere eşittir.");
            Console.WriteLine($"decimal : {Unsafe.SizeOf<decimal>()} byte (Ya da birim hücre) yer kaplar. {Unsafe.SizeOf<decimal>() * 8} bit değere eşittir.");
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
