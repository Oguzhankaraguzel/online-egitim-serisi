using System;
using System.Collections.Generic;
using System.IO;

namespace Gelismis_Tipler_Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Stack<string> books = new Stack<string>();
            //books.Push("Kürk Mantolu Madonna");
            //books.Push("Beyaz Diş");
            //books.Push("Değirmen");

            //string book = books.Peek();

            //Console.WriteLine(book);

            Stack<string> history = new Stack<string>();

            void GoToUrl(string url)
            {
                history.Push(url);
                Console.WriteLine($"Going To {url}");
            }
            void GoBack()
            {
                history.Pop();
                Console.WriteLine($"Going To {history.Peek()}");
            }
            Console.WriteLine("Url Giriniz");
            string Url = Console.ReadLine();
            GoToUrl(Url);
            while (true)
            {
                Console.WriteLine("Geri gitmek için \"g\" yazın. Url'e Gitmek için url yazın");
                string command = Console.ReadLine();
                if (command == "g")
                {
                    GoBack();
                }
                else
                {
                    GoToUrl(command);
                }
            }
        }
    }
}
