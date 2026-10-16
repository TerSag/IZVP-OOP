using System;
using System.Collections.Generic;

// Окремий namespace для відрефактореного коду
namespace SolidPractice.GoodDesign
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Order
    {
        public List<Product> Products { get; } = new List<Product>();
        public void AddProduct(Product product) => Products.Add(product);
    }

    public interface IDiscountStrategy
    {
        decimal ApplyDiscount(decimal totalSum);
        string GetDiscountName();
    }

    public class TenPercentDiscount : IDiscountStrategy
    {
        public decimal ApplyDiscount(decimal totalSum) => totalSum * 0.10m;
        public string GetDiscountName() => "10%";
    }

    public interface IOrderRepository
    {
        void Save(Order order);
    }

    public class DatabaseOrderRepository : IOrderRepository
    {
        public void Save(Order order) => Console.WriteLine("Замовлення збережено.");
    }

    public interface INotificationService
    {
        void Notify(string message);
    }

    public class EmailNotificationService : INotificationService
    {
        public void Notify(string message) => Console.WriteLine("Повідомлення відправлено.");
    }

    public class OrderProcessor
    {
        private readonly IOrderRepository _repository;
        private readonly INotificationService _notificationService;
        private readonly IDiscountStrategy _discountStrategy;

        public OrderProcessor(
            IOrderRepository repository, 
            INotificationService notificationService,
            IDiscountStrategy discountStrategy)
        {
            _repository = repository;
            _notificationService = notificationService;
            _discountStrategy = discountStrategy;
        }

        public void Process(Order order)
        {
            decimal sum = 0;
            foreach (var p in order.Products)
            {
                Console.WriteLine($"Товар: {p.Name} — {p.Price} грн");
                sum += p.Price;
            }

            Console.WriteLine($"\nСума: {sum} грн");
            decimal discount = _discountStrategy.ApplyDiscount(sum);
            Console.WriteLine($"Знижка: {_discountStrategy.GetDiscountName()}");
            
            decimal total = sum - discount;
            Console.WriteLine($"До сплати: {total} грн\n");

            _repository.Save(order);
            _notificationService.Notify("Ваше замовлення успішно оформлено!");
        }
    }
}