using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Visa.xaml
    /// </summary>
    public partial class Visa : Window, IPayment
    {
        private bool _visaPaymentSucceeded = false;
        public Visa()
        {
            InitializeComponent();
        }


        public bool PaymentSucceeded => _visaPaymentSucceeded;

        public string SucceededMessage => "Visa betaling succes ";

        public string FailedMessage => "De betaling is gefaald";

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            _visaPaymentSucceeded = true;
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
