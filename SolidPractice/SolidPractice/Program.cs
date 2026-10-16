using System;
// Підключаємо обоє просторів імен
using SolidPractice.BadDesign;
using SolidPractice.GoodDesign;

namespace SolidPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=== ПОЧАТКОВИЙ (ПОГАНИЙ) КОД ===");
            var badProcessor = new BadDesign.BadOrderProcessor();
            badProcessor.AddProduct(new BadDesign.Product { Name = "Keyboard", Price = 1500 });
            badProcessor.AddProduct(new BadDesign.Product { Name = "Mouse", Price = 800 });
            badProcessor.ProcessOrder();

            Console.WriteLine("\n-----------------------------------\n");

            Console.WriteLine("=== ВІДРЕФАКТОРЕНИЙ (GOOD SOLID) КОД ===");
            var goodOrder = new GoodDesign.Order();
            goodOrder.AddProduct(new GoodDesign.Product { Name = "Keyboard", Price = 1500 });
            goodOrder.AddProduct(new GoodDesign.Product { Name = "Mouse", Price = 800 });

            GoodDesign.IOrderRepository repo = new GoodDesign.DatabaseOrderRepository();
            GoodDesign.INotificationService notification = new GoodDesign.EmailNotificationService();
            GoodDesign.IDiscountStrategy discount = new GoodDesign.TenPercentDiscount();

            var goodProcessor = new GoodDesign.OrderProcessor(repo, notification, discount);
            goodProcessor.Process(goodOrder);

            Console.ReadLine();
        }
    }
}
