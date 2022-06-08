using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VendingmachineTDD
{
    public class VendingMachine : INotifyPropertyChanged
    {
        private double budget;

        public double Budget
        {
            get => budget;
            set
            {
                budget = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Add2Euro()
        {
            Budget += 2;
        }

        public void Add1Euro()
        {
            Budget += 1;
        }

        public void Refund()
        {
            Budget = 0;
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
