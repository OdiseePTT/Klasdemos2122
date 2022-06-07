using System;

namespace PersonAgeValidator
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        private IAgeValidator ageValidator;

        public Person(string firstName, string lastName, int age, IAgeValidator ageValidator)
        {
            this.ageValidator = ageValidator;

            if (!ageValidator.IsValidAge(age))
            {
                throw new Exception("age invalid");
            }
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public Person(string firstName, string lastName, int age) : this(firstName, lastName, age, new AgeValidator())
        {
        }


        //public Person(string firstName, string lastName, int age, IAgeValidator ageValidator)
        //{
        //    this.ageValidator = ageValidator;

        //    CreatePerson(firstName, lastName, age);
        //}

        //public Person(string firstName, string lastName, int age)
        //{

        //    CreatePerson(firstName, lastName, age);
        //}

        //private void CreatePerson(string firstName, string lastName, int age)
        //{
        //    if (!ageValidator.IsValidAge(age))
        //    {
        //        throw new Exception("age invalid");
        //    }
        //    FirstName = firstName;
        //    LastName = lastName;
        //    Age = age;
        //}

    }
}
