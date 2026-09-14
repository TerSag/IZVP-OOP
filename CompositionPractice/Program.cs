using System;

namespace CompositionPractice
{
    public class Engine
    {
        public int HorsePower { get; private set; }

        public Engine(int hp)
        {
            HorsePower = hp;
            Console.WriteLine($"[Engine] Створено двигун потужністю {HorsePower} к.с.");
        }

        public void Start()
        {
            Console.WriteLine("[Engine] Двигун запущено. Системи в нормі.");
        }

        public void Stop()
        {
            Console.WriteLine("[Engine] Двигун зупинено.");
        }
    }

    public class Car
    {
        public string Model { get; set; }

        private Engine _engine;

        public Car(string model, int enginePower)
        {
            Model = model;

            _engine = new Engine(enginePower);

            Console.WriteLine($"[Car] Зібрано автомобіль '{Model}'.\n");
        }

        public void Drive()
        {
            Console.WriteLine($"[Car] '{Model}' готується до поїздки.");
            _engine.Start();
            Console.WriteLine($"[Car] '{Model}' почав рух.\n");
        }

        public void Park()
        {
            Console.WriteLine($"[Car] '{Model}' паркується.");
            _engine.Stop();
            Console.WriteLine($"[Car] '{Model}' успішно припарковано.\n");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Демонстрація Композиції ===\n");

            Car myCar = new Car("BMW M5 e60", 635);

            myCar.Drive();
            myCar.Park();

            Console.ReadLine();
        }
    }
}
