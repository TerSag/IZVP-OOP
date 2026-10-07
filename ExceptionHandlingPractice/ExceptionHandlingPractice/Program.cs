using System;

namespace ExceptionHandlingPractice
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
            {
                throw new ArgumentException("Початковий баланс не може бути від'ємним.");
            }
            Balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сума зняття має бути більшою за нуль.");
            }

            if (amount > Balance)
            {
                throw new InvalidOperationException($"Недостатньо коштів на рахунку. Доступно: {Balance}");
            }

            Balance -= amount;
            Console.WriteLine($"[Операція] Успішно знято: {amount} грн. Залишок: {Balance} грн.");
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Сума поповнення має бути більшою за нуль.");
            }

            Balance += amount;
            Console.WriteLine($"[Операція] Успішно поповнено: {amount} грн. Новий баланс: {Balance} грн.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Демонстрація обробки винятків ===\n");

            BankAccount account = new BankAccount(1000m);
            Console.WriteLine($"Створено рахунок. Баланс: {account.Balance} грн.\n");

            Console.WriteLine("--- УСПІШНІ ОПЕРАЦІЇ ---");
            try
            {
                account.Deposit(500m);
                account.Withdraw(200m);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }

            Console.WriteLine("\n--- ПОМИЛКА: Від'ємна сума ---");
            try
            {
                account.Deposit(-50m);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Відловлено ArgumentOutOfRangeException]: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine("\n--- ПОМИЛКА: Недостатньо коштів ---");
            try
            {
                account.Withdraw(5000m);
            }
            catch (InvalidOperationException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Відловлено InvalidOperationException]: {ex.Message}");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}
