using System;
using System.Collections.Generic;

namespace Gelismis_tipler_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> books = new Queue<string>();

            //books.Enqueue("Kürk Mantolu Madonna");
            //books.Enqueue("Değirmen");
            //books.Enqueue("Beyaz Diş");

            ////string book = books.Dequeue();
            //string book = books.Peek();
            //Console.WriteLine(book);
            Console.WriteLine("Kuyruğa kitap eklemek için \"e\" \n Kuyruktan kitap okumak için \"o\" \nLütfen komutunuz giriniz");
            while (true)
            {
                string Command = Console.ReadLine();
                if (Command == "e")
                {
                    string book = Console.ReadLine();
                    books.Enqueue(book);
                    Console.WriteLine($"{book} kuyruğa eklendi");
                }
                else if (Command == "o")
                {
                    string book = books.Dequeue();
                    Console.WriteLine($"{book} okundu");
                }
                else
                {
                    Console.WriteLine("Hatalı Komut Girdiniz. Lütfen Tekrar Deneyiniz");
                }
            }
        }
    }
}
