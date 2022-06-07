using NUnit.Framework;
using System;

namespace PersonAgeValidator.Tests._2
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void Ctor_WithValidUser_ReturnsUser()
        {
            // Arrange
            string firstname = "John";
            string lastname = "Doe";
            int age = 20;
            IAgeValidator stubValidator = new StubAgeValidator(true);

            // Act
            Person person = new Person(firstname, lastname, age, stubValidator);

            // Assert

            Assert.AreEqual(firstname, person.FirstName);
            Assert.AreEqual(lastname, person.LastName);
            Assert.AreEqual(age, person.Age);
        }

        [Test]
        public void Ctor_WithInvalidUser_ThrowsError()
        {
            // Arrange
            string firstname = "John";
            string lastname = "Doe";
            int age = 20;
            IAgeValidator stubValidator = new StubAgeValidator(false);

            // Act
            Assert.Throws<Exception>(() =>
            {
                Person person = new Person(firstname, lastname, age, stubValidator);

            });

        }
    }
}
