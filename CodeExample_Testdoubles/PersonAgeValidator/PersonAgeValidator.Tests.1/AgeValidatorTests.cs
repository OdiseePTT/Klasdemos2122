using NUnit.Framework;

namespace PersonAgeValidator.Tests._1
{
    [TestFixture]
    class AgeValidatorTests
    {

        [TestCase(0)]
        [TestCase(17)]
        [TestCase(71)]
        [TestCase(100)]
        public void IsValidAge_WithAgeBelow18OrAbove70_ReturnsFalse(int age)
        {
            // Arrange
            AgeValidator sut = new AgeValidator();

            // Act
            bool result = sut.IsValidAge(age);

            // Assert
            Assert.IsFalse(result);
        }


        [TestCase(18)]
        [TestCase(19)]
        [TestCase(50)]
        [TestCase(70)]
        public void IsValidAge_WithAgeAbove18AndBelow70_ReturnsTrue(int age)
        {
            // Arrange
            AgeValidator sut = new AgeValidator();

            // Act
            bool result = sut.IsValidAge(age);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
