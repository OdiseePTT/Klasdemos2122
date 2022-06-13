using System.Windows;

namespace BlackJack
{

    public interface ICoordinator
    {
        void OpenLogin();

        void OpenBlackJack(int id);

        void OpenCreateAccount();

        void ShowMessageBox(string message);

    }
    public class Coordinator : ICoordinator
    {
        private Window _window;

        private Window Window
        {
            get
            {
                if (_window == null)
                {
                    _window = new MainWindow();
                    _window.Show();
                }
                return _window;
            }
        }


        public void OpenLogin()
        {
            LoginPage loginPage = new LoginPage();
            loginPage.DataContext = new LoginViewModel(this, new UserDataRepository());
            Window.Content = loginPage;
        }

        public void OpenBlackJack(int id)
        {

            BlackJackPage blackJackPage = new BlackJackPage();
            blackJackPage.DataContext = new BlackJackViewModel(this, id);
            Window.Content = blackJackPage;
        }

        public void OpenCreateAccount()
        {
            CreateAccountPage createAccountPage = new CreateAccountPage();
            createAccountPage.DataContext = new CreateAccountViewModel(this, new UserDataRepository());
            Window.Content = createAccountPage;
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
