using NUnit.Framework;
using System;

namespace PersonAgeValidator.Tests._1
{
    [TestFixture]
    public class PersonTests
    {

        [TestCase(18)]
        [TestCase(19)]
        [TestCase(50)]
        [TestCase(70)]
        public void Ctor_WithValidUser_ReturnsUser(int age)
        {
            // Arrange
            string firstname = "John";
            string lastname = "Doe";

            // Act
            Person person = new Person(firstname, lastname, age);

            // Assert

            Assert.AreEqual(firstname, person.FirstName);
            Assert.AreEqual(lastname, person.LastName);
            Assert.AreEqual(age, person.Age);
        }

        [TestCase(0)]
        [TestCase(17)]
        [TestCase(71)]
        [TestCase(100)]
        public void Ctor_WithInvalidUser_ThrowsError(int age)
        {
            // Arrange
            string firstname = "John";
            string lastname = "Doe";

            // Act
            Assert.Throws<Exception>(() =>
            {
                Person person = new Person(firstname, lastname, age);

            });

        }
    }
}
