using System;
using System.Collections.Generic;

namespace GradesHelper.Tests.helpers
{
    internal class SpyGradeRepository : IGradeRepository
    {
        public bool AddScoreCalled = false;
        public int LatestScoreAdded;
        public void AddScore(Student student, int score)
        {
            AddScoreCalled = true;
            LatestScoreAdded = score;
        }

        public void ClearScore(Student student)
        {
            throw new NotImplementedException();
        }

        public List<int> GetGrades(Student student)
        {
            throw new NotImplementedException();
        }

        public int GetTotalScore(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
