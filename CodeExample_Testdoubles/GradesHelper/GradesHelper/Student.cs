using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GradesHelper
{
    public class Student
    {
        public Student(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Scores = new List<int>();
        }

        public Student()
        {
            Scores = new List<int>();
        }

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<int> Scores { get; set; }
    }
}