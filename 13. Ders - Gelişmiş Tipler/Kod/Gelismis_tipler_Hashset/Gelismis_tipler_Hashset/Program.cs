using System;
using System.Collections.Generic;

namespace Gelismis_tipler_Hashset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> ClassA = new HashSet<int>();
            ClassA.Add(1001);
            ClassA.Add(1002);
            ClassA.Add(1003);

            HashSet<int> ClassB = new HashSet<int>();
            ClassB.Add(1001);
            ClassB.Add(1002);
            ClassB.Add(1003);
            ClassB.Add(1004);
            ClassB.Add(1005);

            //bool isSubSet = ClassB.IsSupersetOf(ClassA);
            //if (isSubSet) 
            //{
            //    Console.WriteLine("B sınıfı A sınıfının üst kümnesidir");
            //}

            ClassB.IntersectWith(ClassA);
            foreach (int i in ClassA) 
            {
                Console.WriteLine(i);
            }
        }
    }
}
