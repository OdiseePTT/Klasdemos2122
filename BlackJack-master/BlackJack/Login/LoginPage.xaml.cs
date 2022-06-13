using System.Windows.Controls;

namespace BlackJack
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
        {
            ((LoginViewModel)DataContext).Password = passwordBox.Password;
        }
    }
}
