using System;
using System.Collections.Generic;

namespace ParcelDeliverySystem
{
    // 1. ШАБЛОН SINGLETON (Налаштування служби)

    public sealed class DeliveryService
    {
        private static DeliveryService _instance;
        private static readonly object _lock = new object();

        public string ServiceName { get; set; } = "FastDelivery";

        private DeliveryService() { }

        public static DeliveryService Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new DeliveryService();
                    }
                    return _instance;
                }
            }
        }
    }
    
    // 2. ШАБЛОН OBSERVER (Інтерфейси та обродники)
    public interface IParcelObserver
    {
        void Update(Parcel parcel);
    }

    public class ClientObserver : IParcelObserver
    {
        private readonly string _name;
        public ClientObserver(string name) => _name = name;

        public void Update(Parcel parcel)
        {
            Console.WriteLine($"  [Observer -> Клієнт {_name}]: Статус вашої посилки {parcel.TrackingNumber} змінено на '{parcel.Status}'.");
        }
    }

    public class ManagerObserver : IParcelObserver
    {
        private readonly string _name;
        public ManagerObserver(string name) => _name = name;

        public void Update(Parcel parcel)
        {
            Console.WriteLine($"  [Observer -> Менеджер {_name}]: Журнал системи оновлено. Посилка {parcel.TrackingNumber} -> '{parcel.Status}'.");
        }
    }

    // ІЄРАРХІЯ ПОСИЛОК ТА ШАБЛОН FACTORY
    public abstract class Parcel
    {
        public string TrackingNumber { get; set; }
        public double WeightKg { get; set; }
        public string Status { get; private set; } = "Створено";

        private readonly List<IParcelObserver> _observers = new List<IParcelObserver>();

        protected Parcel(string trackingNumber, double weightKg)
        {
            TrackingNumber = trackingNumber;
            WeightKg = weightKg;
        }

        public void Attach(IParcelObserver observer) => _observers.Add(observer);
        public void Detach(IParcelObserver observer) => _observers.Remove(observer);

        public void SetStatus(string newStatus)
        {
            Status = newStatus;
            NotifyObservers();
        }

        private void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public abstract string GetParcelType();
    }

    public class SmallParcel : Parcel
    {
        public SmallParcel(string trackingNumber, double weightKg) : base(trackingNumber, weightKg) { }
        public override string GetParcelType() => "SmallParcel (Малогабаритна посилка)";
    }

    public class HeavyParcel : Parcel
    {
        public HeavyParcel(string trackingNumber, double weightKg) : base(trackingNumber, weightKg) { }
        public override string GetParcelType() => "HeavyParcel (Важкогабаритна посилка)";
    }

    public static class ParcelFactory
    {
        public static Parcel CreateParcel(string trackingNumber, double weightKg)
        {
            if (weightKg <= 5.0)
            {
                return new SmallParcel(trackingNumber, weightKg);
            }
            return new HeavyParcel(trackingNumber, weightKg);
        }
    }

    // 3. ШАБЛОН STRATEGY (Розрахунок тарифу)

    public interface ICostCalculationStrategy
    {
        decimal CalculateCost(Parcel parcel);
    }

    public class StandardDeliveryStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(Parcel parcel)
        {
            return 50m + (decimal)parcel.WeightKg * 10m;
        }
    }

    public class ExpressDeliveryStrategy : ICostCalculationStrategy
    {
        public decimal CalculateCost(Parcel parcel)
        {
            return 100m + (decimal)parcel.WeightKg * 25m;
        }
    }

    public class DeliveryCostCalculator
    {
        private ICostCalculationStrategy _strategy;

        public DeliveryCostCalculator(ICostCalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public void SetStrategy(ICostCalculationStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal Calculate(Parcel parcel) => _strategy.CalculateCost(parcel);
    }


    // ГОЛОВНА ПРОГРАМА (Демонстрація)

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            DeliveryService service = DeliveryService.Instance;
            Console.WriteLine($"Служба доставки: {service.ServiceName}");

            string trackingNum = "PKG-001";
            double weight = 3.0;
            Parcel parcel = ParcelFactory.CreateParcel(trackingNum, weight);

            Console.WriteLine($"Посилка: {parcel.TrackingNumber}");
            Console.WriteLine($"Вага: {parcel.WeightKg} кг");
            Console.WriteLine($"Factory створила: {parcel.GetParcelType()}\n");

            var client = new ClientObserver("Іван");
            var manager = new ManagerObserver("Олексій");
            parcel.Attach(client);
            parcel.Attach(manager);

            Console.WriteLine("--- Зміна стану посилки ---");
            parcel.SetStatus("У дорозі");
            Console.WriteLine("\n--- Розрахунок вартості (Strategy) ---");
            var calculator = new DeliveryCostCalculator(new StandardDeliveryStrategy());
            Console.WriteLine($"Стандартний тариф: {calculator.Calculate(parcel)} грн");

            calculator.SetStrategy(new ExpressDeliveryStrategy());
            Console.WriteLine($"Експрес тариф: {calculator.Calculate(parcel)} грн");

            Console.WriteLine("\n--- Завершення доставки ---");
            parcel.SetStatus("Доставлено у відділення");

            Console.ReadLine();
        }
    }
}
