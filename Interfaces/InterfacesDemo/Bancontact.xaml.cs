using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Bancontact.xaml
    /// </summary>
    public partial class Bancontact : Window, IPayment
    {
        private bool _bancontactPaymentSucceeded = false;
        public Bancontact()
        {
            InitializeComponent();
        }

        public bool PaymentSucceeded => _bancontactPaymentSucceeded;

        public string SucceededMessage => "Bancontact betaling succes ";

        public string FailedMessage => "De betaling is gefaald";

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            _bancontactPaymentSucceeded = true;
            Close();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        public void OpenPaymentScreen()
        {
            ShowDialog();
        }
    }
}
