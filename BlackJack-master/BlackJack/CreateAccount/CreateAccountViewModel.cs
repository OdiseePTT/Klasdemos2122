using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Media;

namespace BlackJack
{
    public class CreateAccountViewModel : INotifyPropertyChanged
    {
        private ICoordinator coordinator;
        private IUserDataRepository userDataRepository;
        private string username;
        private string password;
        private string checkPassword;
        private Brush usernameBackgroundColor;
        private Brush passwordBackgroundColor;
        private Brush checkPasswordBackgroundColor;
        private bool createAccountButtonEnabled = false;

        public event PropertyChangedEventHandler PropertyChanged;

        public string CheckPassword
        {
            get => checkPassword;
            set
            {
                checkPassword = value;
                if (!CheckPasswordIsValid(value))
                {
                    CheckPasswordBackgroundColor = Brushes.Red;
                }
                else
                {
                    CheckPasswordBackgroundColor = null;
                }

                CheckCreateAccountButton();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;

                if (!PasswordIsValid(value))
                {
                    PasswordBackgroundColor = Brushes.Red;
                }
                else
                {
                    PasswordBackgroundColor = null;
                }
                CheckCreateAccountButton();

            }
        }


        public string Username
        {
            get => username;
            set
            {
                username = value;
                if (!UsernameIsValid(value))
                {
                    UserBackgroundColor = Brushes.Red;
                }
                else
                {
                    UserBackgroundColor = null;
                }
                CheckCreateAccountButton();

            }
        }


        public Brush UserBackgroundColor
        {
            get => usernameBackgroundColor;
            private set
            {
                usernameBackgroundColor = value;
                OnPropertyChanged();
            }
        }
        public Brush PasswordBackgroundColor
        {
            get => passwordBackgroundColor;
            private set
            {
                passwordBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        public Brush CheckPasswordBackgroundColor
        {
            get => checkPasswordBackgroundColor;
            set
            {
                checkPasswordBackgroundColor = value;
                OnPropertyChanged();
            }
        }

        public bool CreateAccountButtonEnabled
        {
            get => createAccountButtonEnabled;
            private set
            {
                createAccountButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public ActionCommand CancelCommand { get; private set; }
        public ActionCommand CreateAccountCommand { get; private set; }

        public CreateAccountViewModel(ICoordinator coordinator, IUserDataRepository userDataRepository)
        {
            this.coordinator = coordinator;
            this.userDataRepository = userDataRepository;

            CancelCommand = new ActionCommand(CancelCommandAction);
            CreateAccountCommand = new ActionCommand(CreateAccountCommandAction);
        }

        private void CreateAccountCommandAction()
        {
            int id = userDataRepository.CreateUser(Username, Password);
            coordinator.OpenBlackJack(id);
        }

        private void CancelCommandAction()
        {
            coordinator.OpenLogin();
        }

        private bool UsernameIsValid(string value)
        {
            return !string.IsNullOrEmpty(value) && !userDataRepository.UsernameExists(value);
        }


        // Paswoord moet bestaan uit minstens 8 karakters waaronder 1 kleine letter, 1 hoofd letter, 1 cijfer
        private bool PasswordIsValid(string value)
        {

            Regex regex = new Regex(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$");

            return !string.IsNullOrEmpty(value) && regex.IsMatch(value);

        }

        private bool CheckPasswordIsValid(string value)
        {
            return value == Password;
        }

        private void CheckCreateAccountButton()
        {
            CreateAccountButtonEnabled = UsernameIsValid(Username) && PasswordIsValid(Password) && CheckPasswordIsValid(CheckPassword);
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