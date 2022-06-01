using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EF_examples_CodeFirst
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Score> Scores { get; set; }

        public Student(string name)
        {
            Name = name;
            Scores = new List<Score>();
        }

        public Student()
        {
            Scores = new List<Score>();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}