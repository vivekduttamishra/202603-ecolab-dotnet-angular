

using System.Security.Principal;

namespace ConceptArchitect.Finance
{
    public class BankAccount
    {
        private int accountNumber;
        private string name;
        private string password;
        private double balance;
        private double interestRate;

        public BankAccount(int accountNumber, string name, string password, int amount, double interestRate)
        {
            CreateAccount(accountNumber, name, password, amount, interestRate);
        }

        private void CreateAccount(int accountNumber, string name, string password, int amount, double interestRate)
        {
            this.accountNumber= accountNumber;
            this.name = name;
            this.password=password;
            this.balance = amount;
            this.interestRate= interestRate;
        }

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