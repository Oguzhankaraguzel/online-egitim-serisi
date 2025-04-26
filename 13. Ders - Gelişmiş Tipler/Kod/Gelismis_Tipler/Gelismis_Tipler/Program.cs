using System;
using System.Collections.Generic;

namespace Gelismis_Tipler
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*vri tipim  değişken adım = değer   başlangıç değerleri ile oluşturalabilir*/
            List<int> numbers = new List<int>() { 3, 5, 7, 9, 12};
            numbers.Add(5); /*elemanı ekler*/
            numbers.Add(3);
            
            //Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Capacity);
            numbers.Remove(3); /* ilk bulduğu elemanı çıkartır. bulamazsa hate vermez*/
            //Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Capacity);
            numbers.RemoveAt(3);
            //Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Capacity);
            numbers.RemoveRange(0,3);
            //Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Capacity);
            numbers.Sort();
            //Console.WriteLine(numbers.Count);
            Console.WriteLine(numbers.Capacity);
            numbers.Insert(0,2);
            //Console.WriteLine(numbers.Count);
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(3);
            numbers.Add(3);
            Console.WriteLine(numbers.Capacity);
            Console.WriteLine();
            if (numbers.Contains(1)) 
            {
                Console.WriteLine("listede 1 sayısı bulunmakta");
            }
            
            foreach (int i in numbers) 
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            for (int i = 0; i < numbers.Count; i++) 
            {
                Console.WriteLine(numbers[i]);
            }
            _ = numbers.Count; /*listedeki eleman sayısını getirir.*/
            
        }
    }
}
