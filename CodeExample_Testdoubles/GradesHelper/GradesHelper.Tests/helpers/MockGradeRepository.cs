using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GradesHelper.Tests.helpers
{
    internal class MockGradeRepository : IGradeRepository
    {
        public void AddScore(Student student, int score)
        {
            throw new NotImplementedException();
        }

        public void ClearScore(Student student)
        {
            Assert.Pass();
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
