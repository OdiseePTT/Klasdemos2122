using NSubstitute;
using NUnit.Framework;

namespace Guesser.Tests
{
    [TestFixture]
    public class HigherLowerTests
    {
        [Test]
        public void MakeAGuess_WithLowerNumber_ReturnsHigherString()
        {

            IRandom random = Substitute.For<IRandom>();
            random.Next(Arg.Any<int>()).Returns(50);
            HigherLower sut = new HigherLower();

            int i = 25;

            string result = sut.MakeAGuess(i);

            Assert.AreEqual("Higher", result);
        }

        [Test]
        public void MakeAGuessWithCorrectNumber_ReturnsCorrect()
        {
            IRandom random = Substitute.For<IRandom>();
            random.Next(default).ReturnsForAnyArgs(50);

            int guess = 50;
            HigherLower sut = new HigherLower(random);

            string result = sut.MakeAGuess(guess);

            Assert.AreEqual("Correct", result);
        }
    }
}
