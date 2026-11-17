using System;

namespace BankAccountUnitTests
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Початковий баланс не може бути від'ємним.");
            Balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума поповнення повинна бути більшою за нуль.");
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Сума зняття повинна бути більшою за нуль.");
            if (amount > Balance)
                throw new InvalidOperationException("Недостатньо коштів на рахунку.");
            Balance -= amount;
        }
    }
}