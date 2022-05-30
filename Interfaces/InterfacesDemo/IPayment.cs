namespace WpfApp1
{
    interface IPayment
    {
        void OpenPaymentScreen();
        bool PaymentSucceeded { get; }
        string SucceededMessage { get; }
        string FailedMessage { get; }
    }
}
