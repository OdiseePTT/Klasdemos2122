using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqUserExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<User> users = new List<User>()
            {
                new User("Matthias", 32),
                new User("Jef", 35),
                new User("Marie", 29),
                new User("Kim", 34)
            };

            double averageAge = users.Average(GetAge);
            double averageAge1 = users.Average((user) =>
            {
                return user.Age;
            });


            List<string> oldestUsers = users
                .Where((user) => user.Age > 32)
                .OrderByDescending((user)=> user.Age)
                .Select((user) => user.Name)
                .ToList();

            Console.WriteLine(averageAge1);
            Console.WriteLine(oldestUsers);

            Console.ReadKey();
        }


        private static int GetAge(User u)
        {
            return u.Age;
        }



    }

    class User
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}
