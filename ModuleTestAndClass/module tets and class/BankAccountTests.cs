using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BankAccountUnitTests.Tests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Test1_Deposit_ValidAmount_Passes()
        {
            // Arrange
            var account = new BankAccount(100m);

            // Act
            account.Deposit(50m);

            // Assert
            Assert.AreEqual(150m, account.Balance);
        }

        [TestMethod]
        public void Test2_Withdraw_ValidAmount_Passes()
        {
            // Arrange
            var account = new BankAccount(100m);

            // Act
            account.Withdraw(40m);

            // Assert
            Assert.AreEqual(60m, account.Balance);
        }
        [TestMethod]
        public void Test3_Withdraw_InsufficientFunds_Rejected_Passes()
        {
            // Arrange
            var account = new BankAccount(100m);

            // Act & Assert
            bool exceptionThrown = false;
            try
            {
                account.Withdraw(150m);
            }
            catch (InvalidOperationException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
            Assert.AreEqual(100m, account.Balance);
        }

        [TestMethod]
        public void Test4_Deposit_NegativeAmount_Error_Passes()
        {
            // Arrange
            var account = new BankAccount(100m);

            // Act & Assert
            bool exceptionThrown = false;
            try
            {
                account.Deposit(-5m);
            }
            catch (ArgumentException)
            {
                exceptionThrown = true;
            }

            Assert.IsTrue(exceptionThrown);
            Assert.AreEqual(100m, account.Balance);
        }
    }
    }
