

using System.Security.Principal;

namespace ConceptArchitect.Finance
{
    public class BankAccount
    {
        internal int accountNumber;
        internal string name;
        internal string password;
        internal double balance;
        internal double interestRate;

       
        public void Deposit(int amount)
        {
            if (amount < 0)
            {

            }
            else
            {
                balance += amount;
            }
                
        }

        public void Withdraw(int amount, string password)
        {
            if(amount<0)
            {

            }else if(amount > balance)
            {

            } else if (this.password!=password) 
            {

            }
            else
            {
                balance -= amount;
            }

                
        }

        public void CreditInterest()
        {
            balance += balance * interestRate / 1200;
        }

        public void ShowInfo()
        {
            Console.WriteLine(
                $"Account Number={accountNumber}" +
                $"\tName={name}" +
                $"\tBalance={balance}");
        }
    }
}