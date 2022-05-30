using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<StockItem> items = new ObservableCollection<StockItem>();

        public ObservableCollection<StockItem> Items
        {
            get { return items; }
            set { items = value; }
        }

        private ObservableCollection<StockItem> shoppingCart = new ObservableCollection<StockItem>();

        public ObservableCollection<StockItem> ShoppingCart
        {
            get { return shoppingCart; }
            set { shoppingCart = value; }
        }

        private StockItem selectedItem;

        public StockItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                ItemSelected(selectedItem);
            }
        }

        private Boolean bancontactSelected;

        public Boolean BancontactSelected
        {
            get { return bancontactSelected; }
            set { bancontactSelected = value; }
        }
        private Boolean paypallSelected;

        public Boolean PaypallSelected
        {
            get { return paypallSelected; }
            set { paypallSelected = value; }
        }

        private Boolean visaSelected;

        public Boolean VisaSelected
        {
            get { return visaSelected; }
            set { visaSelected = value; }
        }

        private double totalAmount;

        public event PropertyChangedEventHandler PropertyChanged;

        public double TotalAmount
        {
            get { return totalAmount; }
            set
            {
                totalAmount = value;
                PropertyChanged(this, new PropertyChangedEventArgs("TotalAmount"));
            }
        }

        public ICommand CalculateCommand { get; set; }


        public MainViewModel()
        {
            LoadData();
            CalculateCommand = new ActionCommand(CalculateCommandAction);
        }

        private void CalculateCommandAction()
        {
            IPayment payment = null;
            if (VisaSelected)
            {
                payment = new Visa();
            }
            else if (PaypallSelected)
            {
                payment = new Paypal();
            }
            else if (BancontactSelected)
            {
                payment = new Bancontact();
            }



            payment.OpenPaymentScreen();
            if (payment.PaymentSucceeded)
            {
                MessageBox.Show(payment.SucceededMessage);
            }
            else
            {
                MessageBox.Show(payment.FailedMessage);
            }
        }

        private void LoadData()
        {
            Items.Add(new StockItem("Brood", 2.5));
            Items.Add(new StockItem("Hesp", 3));
            Items.Add(new StockItem("Kaas", 2.1));
            Items.Add(new StockItem("Wijn", 7.85));
            Items.Add(new StockItem("Melk", 2));
        }

        private void ItemSelected(StockItem selectedItem)
        {
            if (selectedItem != null)
            {
                Items.Remove(selectedItem);
                ShoppingCart.Add(selectedItem);
                CalculateTotalAmount();
            }
        }

        private void CalculateTotalAmount()
        {
            TotalAmount = 0;
            foreach (StockItem item in ShoppingCart)
            {
                TotalAmount += item.Price;
            }

        }
    }
}
