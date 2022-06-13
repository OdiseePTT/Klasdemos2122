using NUnit.Framework;

namespace BlackJack.Tests
{
    internal class BlackJackGameTests
    {

        [Test]
        public void Ctor_ShufflesDeck()
        {

        }

        [Test]
        public void CalculateValue_WithoutAces_ReturnsCorrectValue()
        {

        }

        [Test]
        public void CalculateValue_WithFaceDownCards_ReturnsValueWithoutValueOfFaceDownCards()
        {

        }

        [Test]
        public void CalculateValue_WithAnAce_ReturnsHightesNotBustedValue()
        {

        }

        [Test]
        public void DealCard_WithMoreThan20CardsInDeck_DoesntresetDeckAndShuffleAndReturnsFirstCard()
        {

        }

        [Test]
        public void DealCard_WithMoreLessThan20CardsInDeck_ResetDeckAndShuffleAndReturnsFirstCard()
        {

        }
    }
}
