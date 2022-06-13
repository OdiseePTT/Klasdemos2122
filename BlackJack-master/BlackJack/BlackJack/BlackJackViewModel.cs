using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace BlackJack
{
    public class BlackJackViewModel : INotifyPropertyChanged
    {
        private double budget = 500;
        private readonly BlackjackGame blackjackGame = new BlackjackGame();
        private bool startGameButtonEnabled = false;
        private bool takeCardButtonEnabled = false;
        private bool stopButtonEnabled = false;
        private bool bidStringEnabled = true;
        private string bidString;
        private double bid;
        private string result;
        private Visibility resultHidden = Visibility.Hidden;
        private int cardValueDealer;
        private int cardValuePlayer;
        private readonly Coordinator coordinator;
        private readonly int userId;
        readonly UserDataRepository userDataRepository = new UserDataRepository();

        private ObservableCollection<Card> DealerCardsCollection { get; set; } = new ObservableCollection<Card>();
        private ObservableCollection<Card> PlayerCardsCollection { get; set; } = new ObservableCollection<Card>();


        public ReadOnlyObservableCollection<Card> DealerCards { get; }
        public ReadOnlyObservableCollection<Card> PlayerCards { get; }

        public double Budget
        {
            get => budget;
            private set
            {
                budget = value;
                OnPropertyChanged();
            }
        }
        public string BidString
        {
            get => bidString;
            set
            {
                bidString = value;
                if (double.TryParse(bidString, out bid))
                {
                    StartGameButtonEnabled = bid > 0 && bid <= Budget;
                }
                else { StartGameButtonEnabled = false; }
            }
        }

        public ActionCommand StartGameCommand { get; private set; }
        public ActionCommand TakeCardCommand { get; private set; }
        public ActionCommand StopCommand { get; private set; }
        public ActionCommand LogOutCommand { get; private set; }

        public bool StartGameButtonEnabled
        {
            get => startGameButtonEnabled;
            private set
            {
                startGameButtonEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool TakeCardButtonEnabled
        {
            get => takeCardButtonEnabled;
            private set
            {
                takeCardButtonEnabled = value;
                OnPropertyChanged();
            }
        }
        public bool StopButtonEnabled
        {
            get => stopButtonEnabled;
            private set
            {
                stopButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public bool BidStringEnabled
        {
            get => bidStringEnabled;
            private set
            {
                bidStringEnabled = value;
                OnPropertyChanged();
            }
        }

        public string Result
        {
            get => result;
            private set
            {
                result = value;
                OnPropertyChanged();
            }
        }
        public Visibility ResultHidden
        {
            get => resultHidden;
            private set
            {
                resultHidden = value;
                OnPropertyChanged();
            }
        }

        public int CardValueDealer
        {
            get => cardValueDealer;
            private set
            {
                cardValueDealer = value;
                OnPropertyChanged();
            }
        }

        public int CardValuePlayer
        {
            get => cardValuePlayer;
            private set
            {
                cardValuePlayer = value;
                OnPropertyChanged();
            }
        }

        public BlackJackViewModel(Coordinator coordinator, int userId)
        {
            LoadCommands();
            DealerCards = new ReadOnlyObservableCollection<Card>(DealerCardsCollection);
            PlayerCards = new ReadOnlyObservableCollection<Card>(PlayerCardsCollection);

            PlayerCardsCollection.CollectionChanged += Cards_CollectionChanged;
            DealerCardsCollection.CollectionChanged += Cards_CollectionChanged;

            this.coordinator = coordinator;
            this.userId = userId;

            Budget = userDataRepository.GetUser(userId).Budget;
            BidString = "10";

        }

        private void Cards_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CardValuePlayer = blackjackGame.CalculateValue(PlayerCardsCollection.ToList());
            CardValueDealer = blackjackGame.CalculateValue(DealerCardsCollection.ToList());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadCommands()
        {
            StartGameCommand = new ActionCommand(StartGameCommandAction);
            TakeCardCommand = new ActionCommand(TakeCardCommandAction);
            StopCommand = new ActionCommand(StopCommandAction);
            LogOutCommand = new ActionCommand(LogOutCommandAction);
        }

        private void LogOutCommandAction()
        {
            coordinator.OpenLogin();
        }

        private void TakeCardCommandAction()
        {
            PlayerCardsCollection.Add(blackjackGame.DealCard());

            if (blackjackGame.CalculateValue(PlayerCards.ToList()) > 21)
            {

                StopCommandAction();
            }
        }

        private void StopCommandAction()
        {
            DealerCards.Last().IsFaceDown = false;
            Cards_CollectionChanged(this, null);

            TakeCardButtonEnabled = false;
            StopButtonEnabled = false;

            if (!(CardValuePlayer == 21 && PlayerCards.Count() == 2) && CardValuePlayer <= 21)
            {
                while (blackjackGame.CalculateValue(DealerCards.ToList()) < 17)
                {
                    DealerCardsCollection.Add(blackjackGame.DealCard());
                }
            }

            FindWinner();

            BidStringEnabled = true;
            BidString = BidString;
        }

        private void FindWinner()
        {
            if (CardValuePlayer == 21 && PlayerCardsCollection.Count == 2)
            {
                if (CardValueDealer == 21 && DealerCardsCollection.Count == 2)
                {
                    Draw();
                }
                else
                {
                    BlackJack();
                }
            }
            else if (CardValuePlayer > 21)
            {
                Lost();
            }
            else if (CardValueDealer > 21)
            {
                Won();
            }
            else if (CardValueDealer == CardValuePlayer)
            {
                Draw();
            }
            else if (CardValuePlayer > CardValueDealer)
            {
                Won();
            }
            else
            {
                Lost();
            }
        }

        private void Won()
        {
            Result = "Gewonnen";
            ResultHidden = Visibility.Visible;

            UpdateBudget(2 * bid);
        }

        private void Lost()
        {
            Result = "Verloren";
            ResultHidden = Visibility.Visible;
        }
        private void Draw()
        {
            Result = "Gelijk";
            ResultHidden = Visibility.Visible;
            UpdateBudget(bid);

        }
        private void BlackJack()
        {
            Result = "BlackJack!";
            ResultHidden = Visibility.Visible;
            UpdateBudget(2.5 * bid);

        }

        private void UpdateBudget(double change)
        {
            userDataRepository.UpdateBudget(userId, change);
            Budget = userDataRepository.GetUser(userId).Budget;
        }


        private void StartGameCommandAction()
        {
            PlayerCardsCollection.Clear();
            DealerCardsCollection.Clear();
            UpdateBudget(-bid);

            PlayerCardsCollection.Add(blackjackGame.DealCard());
            PlayerCardsCollection.Add(blackjackGame.DealCard());

            DealerCardsCollection.Add(blackjackGame.DealCard());
            Card c = blackjackGame.DealCard();
            c.IsFaceDown = true;
            DealerCardsCollection.Add(c);

            BidStringEnabled = false;
            StartGameButtonEnabled = false;

            TakeCardButtonEnabled = true;
            StopButtonEnabled = true;
            ResultHidden = Visibility.Hidden;

        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
