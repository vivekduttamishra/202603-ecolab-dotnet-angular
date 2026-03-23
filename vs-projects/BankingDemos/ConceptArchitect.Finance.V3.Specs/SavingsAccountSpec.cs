using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance.V3.Specs
{
    public class SavingsAccountSpec
    {
        string name = "Savings Account";
        string password = "p@ss";
        double amount = 20000;
        double interestRate = 12;
        int accountNumber = 1;

        SavingsAccount account;

        public SavingsAccountSpec()
        {
            account = new SavingsAccount(accountNumber, name, password, amount);
        }

        [Fact]
        public void SavingAccountObjectsAreOfTypeSavingsAccount()
        {
            
            Assert.IsType(typeof(SavingsAccount),account);
        }

        [Fact]
        public void SavingsAccountIsATypeOfBankAccount()
        {
           
            Assert.True(account is BankAccount);
        }

        [Fact]
        public void SavingsAccountHasMinBalance()
        {
            Assert.True(account.MinBalance is int);
        }

        [Fact]
        public void Deposit_SucceedsForPositiveAmount()
        {
            account.Deposit(1);

            Assert.Equal(amount+1, account.Balance);
        }

        [Fact]
        public void Withdraw_FailsForAmountExceedingBalance_minus_MinBalance()
        {
            var result = account.Withdraw(amount - account.MinBalance + 1, password);

            Assert.False(result);
            Assert.Equal(amount, account.Balance);
        }
    }
}
