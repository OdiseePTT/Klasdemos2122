using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlackJack
{
    public class Card : INotifyPropertyChanged
    {
        private bool isFaceDown;

        public Suits Suit { get; set; }
        public string SuitString => ConvertSuit();

        public string FaceLetter => ConvertFaceNumber();

        public int FaceNumber { get; set; }
        public bool IsFaceDown
        {
            get => isFaceDown;
            set
            {
                isFaceDown = value;
                OnPropertyChanged();
            }
        }

        public Card(Suits suit, int faceNumber)
        {
            Suit = suit;
            FaceNumber = faceNumber;
            IsFaceDown = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private string ConvertFaceNumber()
        {
            switch (FaceNumber)
            {
                case 1:
                    return "A";
                case 2:
                    return Convert.ToString(FaceNumber);
                case 3:
                    return Convert.ToString(FaceNumber);
                case 4:
                    return Convert.ToString(FaceNumber);
                case 5:
                    return Convert.ToString(FaceNumber);
                case 6:
                    return Convert.ToString(FaceNumber);
                case 7:
                    return Convert.ToString(FaceNumber);
                case 8:
                    return Convert.ToString(FaceNumber);
                case 9:
                    return Convert.ToString(FaceNumber);
                case 10:
                    return Convert.ToString(FaceNumber);
                case 11:
                    return "J";
                case 12:
                    return "Q";
                case 13:
                    return "K";
                default:
                    return "";
            }
        }

        private string ConvertSuit()
        {
            switch (Suit)
            {
                case Suits.Spades:
                    return "spades";
                case Suits.Hearts:
                    return "hearts";
                case Suits.Diamonds:
                    return "diamonds";
                case Suits.Clubs:
                    return "clubs";
                default:
                    break;
            }
            return "";
        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
