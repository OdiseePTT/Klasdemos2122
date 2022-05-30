using NUnit.Framework;

namespace Calculator.Tests
{
    public class CalculatorTests
    {

        [Test]
        public void IsEven_WithEvenNumber_ReturnsTrue()
        {
            // Arrange
            Calculator sut = new Calculator();
            int evenNumber = 6;

            // Act
            bool result = sut.IsEven(evenNumber);

            // Assert
            Assert.IsTrue(result);

        }

        [Test]
        public void IsEven_WithOddNumber_ReturnsTrue()
        {
            // Arrange
            Calculator sut = new Calculator();
            int oddNumber = 7;

            // Act
            bool result = sut.IsEven(oddNumber);

            // Assert
            Assert.IsFalse(result);

        }

        [TestCase(6, ExpectedResult = true)]
        [TestCase(7, ExpectedResult = false)]
        [TestCase(8, ExpectedResult = true)]
        [TestCase(10001, ExpectedResult = false)]
        [TestCase(0, ExpectedResult = true)]
        [TestCase(-1, ExpectedResult = false)]
        public bool IsEven_WithNumber_ReturnsCorrectResult(int number)
        {
            // Arrange
            Calculator sut = new Calculator();  

            // Act
            bool result = sut.IsEven(number);

            return result;
        }

    }
}
