using System.Collections.Generic;
using System.Linq;

namespace EF_examples_CodeFirst
{
    internal class ScoreRepository
    {
        StudentScoreDB db = new StudentScoreDB();

        public List<Score> GetScoresForStudent(Student s)
        {
            return db.Scores.Where(score => score.Student.Id == s.Id).ToList();
        }

        public void AddScoreForStudent(int score, Student s)
        {
            Student currentStudent = db.Students.First(student => student.Id == s.Id);
            Score scoreToSave = new Score(score, currentStudent);
            db.Scores.Add(scoreToSave);
            db.SaveChanges();
        }
    }
}
