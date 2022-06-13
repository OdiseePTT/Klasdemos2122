using System.Windows.Controls;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for CreateAccountPage.xaml
    /// </summary>
    public partial class CreateAccountPage : Page
    {
        public CreateAccountPage()
        {
            InitializeComponent();
        }

        private void checkPasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            ((CreateAccountViewModel)DataContext).CheckPassword = checkPasswordBox.Password;
        }

        private void passwordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            ((CreateAccountViewModel)DataContext).Password = passwordBox.Password;

        }
    }
}
