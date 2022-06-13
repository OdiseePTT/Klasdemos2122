using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlackJack
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        readonly ICoordinator coordinator;
        private string password;
        private string username;
        private bool loginButtonEnabled = false;
        readonly IUserDataRepository userDataRepository;

        public event PropertyChangedEventHandler PropertyChanged;

        public ActionCommand LoginCommand { get; private set; }
        public ActionCommand CreateAccountCommand { get; private set; }
        public string Password
        {
            get => password;
            set
            {
                password = value;
                CheckLoginButtonEnabled();
            }
        }
        public string Username
        {
            get => username;
            set
            {
                username = value;
                CheckLoginButtonEnabled();
            }
        }

        public bool LoginButtonEnabled
        {
            get => loginButtonEnabled;
            private set
            {
                loginButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public LoginViewModel(ICoordinator coordinator, IUserDataRepository userDataRepository)
        {
            LoginCommand = new ActionCommand(LoginCommandAction);
            CreateAccountCommand = new ActionCommand(CreateAccountCommandAction);
            this.coordinator = coordinator;
            this.userDataRepository = userDataRepository;

        }

        private void CreateAccountCommandAction()
        {
            coordinator.OpenCreateAccount();
        }

        private void LoginCommandAction()
        {
            User user = userDataRepository.Login(Username, Password);
            if (user != null)
            {
                coordinator.OpenBlackJack(user.Id);
            }
            else
            {
                coordinator.ShowMessageBox("Invalid Password");
            }
        }

        private void CheckLoginButtonEnabled()
        {
            LoginButtonEnabled = !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
        }

        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
