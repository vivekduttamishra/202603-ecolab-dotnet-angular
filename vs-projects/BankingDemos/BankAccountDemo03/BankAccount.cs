

using System.Security.Principal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ConceptArchitect.Finance
{
    public class BankAccount
    {
        private int accountNumber;
        private string name;
        private string password;
        private double balance;


        private double interestRate;

        public double InterestRate
        {
            get
            {
                return interestRate;
            }
            set  //(double value)
            {
                var delta = interestRate / 10;
                var min = interestRate - delta;
                var max = interestRate + delta;

                if (value >= min && value < max)
                {
                    interestRate = value;
                }
            }
        }

       


        //public string GetPassword() { return password; }

        public bool Authenticate(string password)
        {
            return this.password == password;
        }

        //public void SetPassword(string value) { password = value; }

        public void ChangePassword(string currentPassword, string newPassword)
        {
            if(Authenticate(currentPassword) )
                password= newPassword;
        }

        public int AccountNumber { get { return accountNumber; } }
        public double Balance { get { return balance; } }



        public string Name {
            get { return name; }
            set {

                var newNameIndex = value.LastIndexOf(" ");
                if (newNameIndex == -1)
                    return;
                var currentNameIndex = name.LastIndexOf(" ");

                var currentLastName = name.Substring(currentNameIndex + 1);
                var newLastName = value.Substring(newNameIndex + 1);

                if (currentLastName == newLastName)
                    name = value;

            }
        }

       


        public BankAccount(int accountNumber, string name, string password, int amount, double interestRate)
        {
            CreateAccount(accountNumber, name, password, amount, interestRate);
        }

        //this code can be merged in BankAccount .
        //we could havde simply renamed this function to BankAccount and remove the return type
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