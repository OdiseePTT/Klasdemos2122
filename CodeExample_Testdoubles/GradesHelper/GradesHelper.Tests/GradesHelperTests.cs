using GradesHelper.Tests.helpers;
using NUnit.Framework;

namespace GradesHelper.Tests
{
    [TestFixture]
    public class GradesHelperTests
    {
        [Test]
        public void CalcAverageGrade_WithGrades_ReturnsAverage()
        {
            // Arrange
            IGradeRepository stubGradeRepository = new StubGradeRepository();
            GradesHelper sut = new GradesHelper(stubGradeRepository);

            // Act
            double result = sut.CalcAverageGrade(null);

            // Assert
            Assert.AreEqual(5.5, result);
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore_BetterScoreAdded_ReturnsTrue()
        {
            // Arrange
            IGradeRepository fakeGradeRepository = new FakeGradeRepository();
            GradesHelper sut = new GradesHelper(fakeGradeRepository);

            // Act
            bool result = sut.DidStudentPerformBetterWithNewScore(null, 4);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveAllScores_CallsClearScores()
        {
            // Arrange
            IGradeRepository mockGradeRepository = new MockGradeRepository();
            GradesHelper sut = new GradesHelper(mockGradeRepository);

            // Act
            sut.RemoveAllScores(null);

            // Assert
            Assert.Fail();

        }

        [Test]
        public void AddScore_WithValidScore_CallsAddScoreInRepository()
        {
            SpyGradeRepository spyGradeRepository = new SpyGradeRepository();
            GradesHelper sut = new GradesHelper(spyGradeRepository);

            sut.AddScore(null, 5);

            Assert.IsTrue(spyGradeRepository.AddScoreCalled);
            Assert.AreEqual(5, spyGradeRepository.LatestScoreAdded);
        }
    }
}
