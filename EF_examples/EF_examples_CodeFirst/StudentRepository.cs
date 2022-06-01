using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EF_examples_CodeFirst
{
    internal class StudentRepository
    {
        StudentScoreDB db = new StudentScoreDB();

        public List<Student> GetAllStudents()
        {
            return db.Students.Include(student => student.Scores).ToList();
        }

        public void CreateStudent(string name)
        {
            Student student = new Student(name);

            db.Students.Add(student);
            db.SaveChanges();
        }
    }
}
