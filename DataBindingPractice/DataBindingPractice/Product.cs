using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DataBindingPractice
{
    public class Product : INotifyPropertyChanged
    {
        private string name;
        private decimal price;
        private int quantity;

        public string Name
        {
            get => name;
            set { name = value; OnPropertyChanged(); }
        }

        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Ціна не може бути від'ємною!");

                price = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get => quantity;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Кількість не може бути від'ємною!");

                quantity = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}