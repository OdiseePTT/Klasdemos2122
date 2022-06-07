using System.Collections.Generic;
using System.Linq;

namespace GradesHelper
{
    public class GradeRepository : IGradeRepository
    {
        private readonly StudentsDbContext studentsDbContext = new StudentsDbContext();

        public GradeRepository(StudentsDbContext studentsDbContext)
        {
            this.studentsDbContext = studentsDbContext;
        }

        public GradeRepository()
        {

        }

        public void AddScore(Student student, int score)
        {
            studentsDbContext.Students.First(s => s.Id == student.Id).Scores.Add(score);
            studentsDbContext.SaveChanges();
        }

        public void ClearScore(Student student)
        {
            studentsDbContext.Students.First(s => s.Id == student.Id).Scores.Clear();
            studentsDbContext.SaveChanges();

        }

        public List<int> GetGrades(Student student)
        {
            return studentsDbContext.Students.First(s => s.Id == student.Id).Scores;
        }

        public int GetTotalScore(Student student)
        {
            return studentsDbContext.Students.First(s => s.Id == student.Id).Scores.Sum();
        }
    }
}
