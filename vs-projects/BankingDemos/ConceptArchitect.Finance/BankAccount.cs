

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
        private static double interestRate;

        public BankAccount(int accountNumber,string name, string password, int amount)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.password = password;
            this.balance = amount;
            //interestRate=rate; //it is static
        }


        static BankAccount()
        {
            interestRate = 12;
        }

        public static double InterestRate
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

        public bool Authenticate(string password)
        {
            return this.password == password;
        }

        public void ChangePassword(string currentPassword, string newPassword)
        {
            if (Authenticate(currentPassword))
                password = newPassword;
        }

        public int AccountNumber { get { return accountNumber; } }
        public double Balance { get { return balance; } }

        public string Name
        {
            get { return name; }
            set
            {

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


        public bool Deposit(int amount)
        {
            if (amount < 0)
            {
                return false; //failed
            }
            else
            {
                balance += amount;
                return true;
            }

        }

        public bool Withdraw(int amount, string password)
        {
            if (amount < 0)
            {
                return false;
            }
            else if (amount > balance)
            {
                return false;
            }
            else if (!Authenticate(password))
            {
                return false;
            }
            else
            {

                balance -= amount;
                return true;
            }


        }

        public bool Transfer(int amount, string password, BankAccount to)
        {
            if (Withdraw(amount, password))
                return to.Deposit(amount);
            else
                return false;
        }

        public void CreditInterest()
        {
            balance += balance * interestRate / 1200;
        }

        public string Info
        {
            get
            {

                return
                        $"Account Number={accountNumber}" +
                        $"\tName={name}" +
                        $"\tBalance={balance}" +
                        $"\tInterest Rate={interestRate}";
            }
        }


    }
}