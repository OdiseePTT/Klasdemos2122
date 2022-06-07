using System;

namespace PersonAgeValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person p = new Person("Matthias", "Druwé", 10);
                Console.WriteLine(p);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
