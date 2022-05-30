using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 40, 24, 43, 246, 54, 34 };
            numbers.Add(40);
            numbers.Add(24);
            numbers.Add(43);
            numbers.Add(346);
            numbers.Add(54);
            numbers.Add(34);



            Console.WriteLine(numbers.Average());

            Console.ReadKey();
        }
    }
}
