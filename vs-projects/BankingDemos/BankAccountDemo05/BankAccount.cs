

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
        private static int lastId = 0;

        public BankAccount(string name, string password, int amount)
        {
            lastId++;
            this.accountNumber = lastId;
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

       


       
        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                System.Console.WriteLine("Invalid Amount");
            }
            else
            {
                System.Console.WriteLine("Amount Deposited: "+amount);
                balance += amount;
            }
                
        }

        public void Withdraw(int amount, string password)
        {
            if(amount<0)
            {
                Console.WriteLine("Negative amount not allowed");
            }else if(amount > balance)
            {
                Console.WriteLine("Insufficient Funds");
            } else if (this.password!=password) 
            {
                Console.WriteLine("Invalid Credentials");
            }
            else
            {
                Console.WriteLine("Please take your cash");
                balance -= amount;
            }

                
        }

        public void Transfer(int amount, string password, BankAccount to)
        {
            Withdraw(amount, password); 
            to.Deposit(amount);
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
                $"\tBalance={balance}" +
                $"\tInterest Rate={interestRate}");
        }

       
    }
}