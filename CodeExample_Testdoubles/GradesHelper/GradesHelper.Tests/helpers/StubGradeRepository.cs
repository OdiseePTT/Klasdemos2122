using System.Collections.Generic;

namespace GradesHelper.Tests.helpers
{
    internal class StubGradeRepository : IGradeRepository
    {
        public void AddScore(Student student, int score)
        {
            throw new System.NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            throw new System.NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            return new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        }

        public int GetTotalScore(Student student)
        {
            throw new System.NotImplementedException();
        }
    }
}
