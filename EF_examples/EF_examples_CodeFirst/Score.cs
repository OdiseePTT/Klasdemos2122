using System.ComponentModel.DataAnnotations;

namespace EF_examples_CodeFirst
{
    public class Score
    {
        public int Value { get; set; }
        public Student Student { get; set; }
        [Key]
        public int Id { get; set; }

        public Score(int value, Student student)
        {
            Value = value;
            Student = student;
        }

        public Score()
        {

        }

        public override string ToString()
        {
            return Value.ToString();
        }

    }
}