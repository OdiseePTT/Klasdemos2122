using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GradesHelper.Tests.NSubstitute
{
    [TestFixture]
    class GradeRepositoryTests
    {

        [Test]
        public void AddScore_AddsANewItemInTheScoreList()
        {
            StudentsDbContext db = Substitute.For<StudentsDbContext>();

            Student s = new Student(1, "Matthias", "Druwé");
            List<Student> students = new List<Student>()
            {
                s
            };

            DbSet<Student> mockDbSet = NSubstituteUtils.GenerateMockDbSet(students);

            db.Students.Returns(mockDbSet);

            GradeRepository sut = new GradeRepository(db);

            sut.AddScore(s, 5);

            Assert.AreEqual(1, s.Scores.Count());
            Assert.Contains(5, s.Scores);

            db.Received(1).SaveChanges();
        }

    }
}
