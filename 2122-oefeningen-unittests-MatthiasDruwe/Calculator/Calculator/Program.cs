using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            Console.WriteLine(calculator.IsEven(6));
            Console.WriteLine(calculator.IsEven(7));
            Console.ReadKey();
        }
    }
}
