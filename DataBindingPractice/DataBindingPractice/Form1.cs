using System;
using System.Windows.Forms;

namespace DataBindingPractice
{
    public partial class Form1 : Form
    {
        private Product currentProduct;

        public Form1()
        {
            InitializeComponent();
            InitializeDataBinding();
        }

        private void InitializeDataBinding()
        {
            currentProduct = new Product { Name = "Ноутбук Dell", Price = 25000, Quantity = 10 };

            txtName.DataBindings.Add("Text", currentProduct, "Name", true, DataSourceUpdateMode.OnPropertyChanged);

            Binding priceBinding = new Binding("Text", currentProduct, "Price", true, DataSourceUpdateMode.OnPropertyChanged);
            priceBinding.BindingComplete += Binding_BindingComplete;
            txtPrice.DataBindings.Add(priceBinding);

            Binding quantityBinding = new Binding("Text", currentProduct, "Quantity", true, DataSourceUpdateMode.OnPropertyChanged);
            quantityBinding.BindingComplete += Binding_BindingComplete;
            txtQuantity.DataBindings.Add(quantityBinding);
        }


        private void Binding_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState != BindingCompleteState.Success)
            {
                string errorMsg = e.Exception?.InnerException?.Message ?? e.ErrorText;
                MessageBox.Show($"Помилка введення: {errorMsg}", "Помилка валідації", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDiscount_Click(object sender, EventArgs e)
        {
            currentProduct.Price *= 0.9m; // знижка 10%
        }

        private void btnShowData_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Дані в пам'яті програми:\n\nНазва: {currentProduct.Name}\nЦіна: {currentProduct.Price} грн\nКількість: {currentProduct.Quantity} шт.",
                            "Поточний стан об'єкта");
        }
    }
}