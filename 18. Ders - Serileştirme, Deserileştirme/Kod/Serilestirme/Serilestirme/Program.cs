using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Xml.Serialization;

namespace Serilestirme
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ogrenci ogrenci = new Ogrenci();
            ogrenci._ad = "Ali";
            ogrenci._soyad = "Veli";
            ogrenci._sinif = "10A";
            ogrenci._yas = 16;

            Ogrenci ogrenci2 = new Ogrenci();
            ogrenci2._ad = "Ayse";
            ogrenci2._soyad = "Fatma";
            ogrenci2._sinif = "10B";
            ogrenci2._yas = 15;

            Ogrenci[] ogrenciler = new Ogrenci[2];
            ogrenciler[0] = ogrenci;
            ogrenciler[1] = ogrenci2;

            //// JSON serileştirme
            //JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions
            //{
            //    WriteIndented = true, // JSON çıktısını daha okunabilir hale getirir
            //    IncludeFields = true // Alanları serileştirir
            //};
            //string json = JsonSerializer.Serialize(ogrenciler, jsonSerializerOptions);

            //// JSON çıktısını dosyaya yazma
            //string dosyaYolu = "ogrenciler.json";
            //File.WriteAllText(dosyaYolu, json);

            //// JSON dosyasını okuma
            //string jsonDosyaIcerigi = File.ReadAllText(dosyaYolu);
            //Ogrenci[] okunanOgrenciler = JsonSerializer.Deserialize<Ogrenci[]>(jsonDosyaIcerigi, jsonSerializerOptions);

            //// XML serileştirme
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Ogrenci[]));
            //using (FileStream fileStream = new FileStream("ogrenciler.xml", FileMode.Create))
            //{
            //    xmlSerializer.Serialize(fileStream, ogrenciler);
            //}
            //// XML dosyasını okuma
            //using (FileStream fileStream = new FileStream("ogrenciler.xml", FileMode.Open))
            //{
            //    Ogrenci[] okunanOgrenciler = (Ogrenci[])xmlSerializer.Deserialize(fileStream);
            //    foreach (var ogr in okunanOgrenciler)
            //    {
            //        Console.WriteLine($"Ad: {ogr._ad}, Soyad: {ogr._soyad}, Sınıf: {ogr._sinif}, Yaş: {ogr._yas}");
            //    }
            //}

            // Binary serileştirme
            using (FileStream fileStream = new FileStream("ogrenciler.dat", FileMode.Create))
            {
                BinaryWriter binaryWriter = new BinaryWriter(fileStream, Encoding.UTF8);
                foreach (var ogr in ogrenciler)
                {
                    binaryWriter.Write(ogr._ad);
                    binaryWriter.Write(ogr._soyad);
                    binaryWriter.Write(ogr._sinif);
                    binaryWriter.Write(ogr._yas);
                }
            }

            using (FileStream reader = new FileStream("ogrenciler.dat", FileMode.Open)) 
            {
                BinaryReader binaryReader = new BinaryReader(reader,Encoding.UTF8);
                Ogrenci[] okunanOgrenciler = new Ogrenci[2];
                reader.Position = 0; // Reset position to the beginning of the file
                int index = 0;
                while (reader.Position < reader.Length)
                {
                    Ogrenci ogr = new Ogrenci();
                    ogr._ad = binaryReader.ReadString();
                    ogr._soyad = binaryReader.ReadString();
                    ogr._sinif = binaryReader.ReadString();
                    ogr._yas = binaryReader.ReadInt32();
                    okunanOgrenciler[index] = ogr; 
                    index++;
                }
            }

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, ogrenciler); //  Binary serileştirme kolay yolu.
        }
    }
    [Serializable]
    public struct Ogrenci
    {
        public string _ad;
        public string _soyad;
        public string _sinif;
        public int _yas;
    }
}
