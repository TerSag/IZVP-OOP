using System;
using System.Collections.Generic;

namespace GenericsPractice
{
    public class Repository<T>
    {
        private List<T> _items = new List<T>();

        public void Add(T item)
        {
            _items.Add(item);
            Console.WriteLine($"[Додано] {item}");
        }

        public int GetCount()
        {
            return _items.Count;
        }

        public void ShowAll()
        {
            Console.WriteLine("Вміст репозиторію:");
            if (_items.Count == 0)
            {
                Console.WriteLine("  Порожньо");
                return;
            }
            foreach (var item in _items)
            {
                Console.WriteLine($"  - {item}");
            }
        }
    }

    class Program
    {
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Демонстрація Generics ===\n");

            Console.WriteLine("--- Робота з Repository<string> ---");
            Repository<string> stringRepo = new Repository<string>();
            stringRepo.Add("Яблуко");
            stringRepo.Add("Груша");
            stringRepo.ShowAll();

            Console.WriteLine("\n--- Робота з Repository<int> ---");
            Repository<int> intRepo = new Repository<int>();
            intRepo.Add(42);
            intRepo.Add(100);
            intRepo.ShowAll();

            Console.WriteLine("\n--- Демонстрація методу Swap<T> ---");

            int x = 10, y = 99;
            Console.WriteLine($"До Swap<int>: x = {x}, y = {y}");
            Swap<int>(ref x, ref y);
            Console.WriteLine($"Після Swap<int>: x = {x}, y = {y}\n");

            string str1 = "Привіт", str2 = "Світ";
            Console.WriteLine($"До Swap<string>: str1 = {str1}, str2 = {str2}");
            Swap<string>(ref str1, ref str2);
            Console.WriteLine($"Після Swap<string>: str1 = {str1}, str2 = {str2}");

            Console.ReadLine();
        }
    }
}