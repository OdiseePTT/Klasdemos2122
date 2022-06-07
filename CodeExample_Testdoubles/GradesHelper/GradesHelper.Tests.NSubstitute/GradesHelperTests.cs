using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace GradesHelper.Tests.NSubstitute
{
    [TestFixture]
    public class GradesHelperTests
    {
        [Test]
        public void CalcAverageGrade_WithGrades_ReturnsAverage()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            Student s = new Student();
            gradeRepository.GetGrades(Arg.Any<Student>()).Returns(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });


            GradesHelper sut = new GradesHelper(gradeRepository);

            // Act
            double result = sut.CalcAverageGrade(null);

            // Assert
            Assert.AreEqual(5.5, result);
        }

        [Test]
        public void DidStudentPerformBetterWithNewScore_BetterScoreAdded_ReturnsTrue()
        {
            // Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            List<int> scores = new List<int>() { 1, 2, 3 };
            gradeRepository.GetGrades(Arg.Any<Student>()).Returns(scores);
            gradeRepository
                .When(repo => repo.AddScore(Arg.Any<Student>(), Arg.Any<int>()))
                .Do(info =>
                {
                    int score = info.ArgAt<int>(1);
                    scores.Add(score);
                });


            GradesHelper sut = new GradesHelper(gradeRepository);

            // Act
            bool result = sut.DidStudentPerformBetterWithNewScore(null, 4);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void RemoveAllScores_CallsClearScores()
        {
            //Arrange
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            gradeRepository.When(repo => repo.ClearScore(Arg.Any<Student>()))
                .Do(_ => Assert.Pass());

            GradesHelper sut = new GradesHelper(gradeRepository);

            // Act
            sut.RemoveAllScores(null);

            // Assert
            Assert.Fail();

        }

        [Test]
        public void AddScore_WithValidScore_CallsAddScoreInRepository()
        {
            IGradeRepository gradeRepository = Substitute.For<IGradeRepository>();
            GradesHelper sut = new GradesHelper(gradeRepository);

            sut.AddScore(null, 5);
            sut.AddScore(null, 5);

            gradeRepository.Received(2).AddScore(Arg.Any<Student>(), 5);
        }
    }
}

