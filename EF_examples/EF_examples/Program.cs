using System;
using System.Linq;

namespace EF_examples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NorthwindDB db = new NorthwindDB();

            Category category = db.Categories.First(c => c.CategoryName == "TEST");

            db.Categories.Remove(category);

            db.SaveChanges();



            Console.ReadKey();
        }
    }
}
