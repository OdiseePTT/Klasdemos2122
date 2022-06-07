using System;
using System.Collections.Generic;

namespace GradesHelper.Tests.helpers
{
    internal class FakeGradeRepository : IGradeRepository
    {

        List<int> scores = new List<int> { 1, 2, 3 };
        public void AddScore(Student student, int score)
        {
            scores.Add(score);
        }

        public void ClearScore(Student student)
        {
            throw new NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            return scores;
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
