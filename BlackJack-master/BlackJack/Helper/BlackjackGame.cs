namespace BlackJack
{
    using System;
    using System.Collections.Generic;

    public class BlackjackGame
    {
        private static int defaultDeckCount = 1;

        private readonly Deck deck;
        private readonly int deckCount = defaultDeckCount;
        public int DeckCount
        {
            get { return deckCount; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("DeckCount", value, "DeckCount must be 1 or higher.");
                }
                deck.Reset(this.deckCount);
                deck.Shuffle();
            }
        }

        public BlackjackGame()
        {
            deck = new Deck(DeckCount);
            deck.Shuffle();
        }

        public int CalculateValue(List<Card> hand)
        {
            int handValue = 0;
            int aceCount = 0;

            foreach (Card card in hand)
            {
                // Face-down card doesn't add to the hand's value.
                if (card.IsFaceDown)
                {
                    continue;
                }

                if (card.FaceNumber <= 10)
                {
                    handValue += card.FaceNumber;
                    if (card.FaceNumber == 1)
                    {
                        ++aceCount;
                    }
                }
                else
                {
                    handValue += 10;
                }
            }

            // Raise one ace to 11 if it will not bust the hand.
            if (handValue <= 11 && aceCount > 0)
            {
                handValue += 10;
            }

            return handValue;
        }

        public Card DealCard()
        {
            if (deck.CardCount < 20)
            {
                deck.Reset();
                deck.Shuffle();
            }
            return deck.DealCard();
        }
    }
}
