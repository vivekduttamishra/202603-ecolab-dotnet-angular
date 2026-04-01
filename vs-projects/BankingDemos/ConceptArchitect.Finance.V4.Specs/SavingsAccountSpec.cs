using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConceptArchitect.Finance.Exceptions;

namespace ConceptArchitect.Finance.V4.Specs
{
    public class SavingsAccountSpec
    {
        string name = "Savings Account";
        string password = "p@ss";
        double amount = 20000;
        double interestRate = 12;
        int accountNumber = 1;

        SavingsAccount account;

        private void AssertBalanceUnchanged()
        {
            Assert.Equal(amount, account.Balance);
        }

        public SavingsAccountSpec()
        {
            account = new SavingsAccount(accountNumber, name, password, amount);
        }

        [Fact]
        public void SavingAccountObjectsAreOfTypeBankAccount()
        {

            Assert.IsAssignableFrom<BankAccount>(account);
        }

        

        [Fact]
        public void SavingsAccountHasMinBalance()
        {
            Assert.IsType<int>(account.MinBalance);
        }

        [Fact]
        public void Deposit_SucceedsForPositiveAmount()
        {
            account.Deposit(1);
            Assert.Equal(amount + 1, account.Balance);
        }

        [Fact]
        public void Withdraw_FailsForAmountExceedingBalance_minus_MinBalance()
        {
            //var result = account.Withdraw(amount - account.MinBalance + 1, password);

            //returns exception that was thrown
            var ex= Assert.Throws<InsufficientBalanceException>(()=>account.Withdraw(amount-account.MinBalance+1, password));

            Assert.Equal(1, ex.Deficit);
            
            AssertBalanceUnchanged();
        }

       
        [Fact]
        public void Withdraw_SucceedsForAmount_minus_MinBalance()
        {
            account.Withdraw(amount - account.MinBalance, password);
            Assert.Equal(account.MinBalance, account.Balance, 0.01);
        }


        [Fact]
        public void CreditInterst_CreditsOneMonthInterest()
        {
            var expectedInterest = amount * interestRate / 1200;

            account.CreditInterest(interestRate);

            Assert.Equal(amount+expectedInterest, account.Balance);

        }
    }
}
