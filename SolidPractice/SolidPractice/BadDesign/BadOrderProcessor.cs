using System;
using System.Collections.Generic;

// Окремий namespace для поганого коду
namespace SolidPractice.BadDesign
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class BadOrderProcessor
    {
        private List<Product> _products = new List<Product>();

        public void AddProduct(Product product) => _products.Add(product);

        public void ProcessOrder()
        {
            decimal sum = 0;
            foreach (var p in _products)
            {
                Console.WriteLine($"Товар: {p.Name} — {p.Price} грн");
                sum += p.Price;
            }

            Console.WriteLine($"\nСума: {sum} грн");
            decimal discount = sum * 0.10m;
            Console.WriteLine("Знижка: 10%");
            decimal totalToPay = sum - discount;
            Console.WriteLine($"До сплати: {totalToPay} грн\n");

            Console.WriteLine("Замовлення збережено.");
            Console.WriteLine("Повідомлення відправлено.");
        }
    }
}