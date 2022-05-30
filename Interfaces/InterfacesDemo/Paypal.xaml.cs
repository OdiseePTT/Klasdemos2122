using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Paypal.xaml
    /// </summary>
    public partial class Paypal : Window, IPayment
    {
        private bool _paypalPaymentSucceeded = false;
        public Paypal()
        {
            InitializeComponent();
        }


        public bool PaymentSucceeded => _paypalPaymentSucceeded;

        public string SucceededMessage => "Paypal betaling succes ";

        public string FailedMessage => "De betaling is gefaald";

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            _paypalPaymentSucceeded = true;
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

        public void DoSomething()
        {
            MessageBox.Show("test");
        }
    }
}
