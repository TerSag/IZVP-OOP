using System;

namespace CustomExceptionsPractice
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class AccountBlockedException : Exception
    {
        public AccountBlockedException(string message) : base(message) { }
    }

    public class BankAccount
    {
        public string Owner { get; private set; }
        public decimal Balance { get; private set; }
        public bool IsBlocked { get; private set; }

        public BankAccount(string owner, decimal initialBalance)
        {
            Owner = owner;
            Balance = initialBalance;
            IsBlocked = false;
        }

        public void BlockAccount()
        {
            IsBlocked = true;
            Console.WriteLine($"[Увага] Рахунок користувача {Owner} було заблоковано!");
        }

        public void Withdraw(decimal amount)
        {
            if (IsBlocked)
            {
                throw new AccountBlockedException($"Спроба зняття відхилена. Рахунок '{Owner}' заблоковано.");
            }

            if (amount > Balance)
            {
                throw new InsufficientFundsException($"Недостатньо коштів. Спроба зняти {amount} грн, але доступно лише {Balance} грн.");
            }

            Balance -= amount;
            Console.WriteLine($"[Успіх] Знято {amount} грн. Залишок: {Balance} грн.");
        }

        public void Deposit(decimal amount)
        {
            if (IsBlocked)
            {
                throw new AccountBlockedException($"Спроба поповнення відхилена. Рахунок '{Owner}' заблоковано.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Сума поповнення має бути більшою за нуль.");
            }

            Balance += amount;
            Console.WriteLine($"[Успіх] Поповнено на {amount} грн. Новий баланс: {Balance} грн.");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Демонстрація користувацьких винятків ===\n");

            BankAccount myAccount = new BankAccount("Іван Петренко", 1000m);
            Console.WriteLine($"Створено рахунок. Власник: {myAccount.Owner}, Баланс: {myAccount.Balance} грн.\n");

            Console.WriteLine("--- 1. Успішний сценарій ---");
            try
            {
                myAccount.Deposit(500m);
                myAccount.Withdraw(200m);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\n--- 2. Помилковий сценарій: Перевищення ліміту ---");
            try
            {
                myAccount.Withdraw(5000m);
            }
            catch (InsufficientFundsException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Помилка фінансів]: {ex.Message}");
                Console.ResetColor();
            }
            catch (AccountBlockedException ex)
            {
                Console.WriteLine($"[Блокування]: {ex.Message}");
            }

            Console.WriteLine("\n--- 3. Помилковий сценарій: Робота із заблокованим рахунком ---");
            myAccount.BlockAccount();
            try
            {
                myAccount.Deposit(100m);
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"[Помилка фінансів]: {ex.Message}");
            }
            catch (AccountBlockedException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Критична помилка]: {ex.Message}");
                Console.ResetColor();
            }

            Console.ReadLine();
        }
    }
}