using NUnit.Framework;
using System.Windows.Media;

namespace BMICalculator.Tests
{
    [TestFixture]
    internal class MainViewModelTests
    {
        [Test]
        public void CalculateCommand_WithLengthAndWeight_SetBMIAndColor()
        {
            // Arrange
            MainViewModel sut = new MainViewModel();
            sut.Weight = 100;
            sut.Length = 2;

            // Act
            sut.CalculateCommand.Execute(null);

            // Assert
            Assert.AreEqual(25, sut.Bmi);
            Assert.AreEqual(Brushes.Yellow, sut.BackgroundColor);
        }


        [Test]
        public void ResetCommand_WithValuesFilled_ClearsAllValues()
        {
            // Arrange
            MainViewModel sut = new MainViewModel();
            sut.Weight = 100;
            sut.Length = 2;
            sut.CalculateCommand.Execute(null);

            // Act
            sut.ResetCommand.Execute(null);

            // Assert 
            Assert.IsNull(sut.Weight);
            Assert.IsNull(sut.Length);
            Assert.IsNull(sut.Bmi);
            Assert.IsNull(sut.BackgroundColor);

        }
    }
}
