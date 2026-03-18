

using ConceptArchitect.Finance;
using System.Runtime.InteropServices;

namespace ConceptArchitect.Finance.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BankAccount v2");


            var account1= new BankAccount(1, "Vivek", "p@ss", 20000, 12);

            //account1.CreateAccount(1, "Vivek", "p@ss", 20000, 12);

            var account2 = new BankAccount(2, "Prabhat", "p@ss2", 50000, 12);

            //account2.CreateAccount(2, "Prabhat", "p@ss2", 50000, 12);


            TestAccount(account1);
            TestAccount(account2);

            //var account3 = new BankAccount();

            //forgot to call
            //account3.CreateAccount(3, "Sanjay", "password", 40000, 12);

            //TestAccount(account3);


            var account4=new BankAccount(4, "Santosh Mall", "pass", 20000, 12);
           
           //        account4.CreateAccount(5, "Santosh", "pass", 30000, 12);

            TestAccount(account4);

           

            Console.WriteLine("Current Rate: "+ account4.InterestRate);
            account4.InterestRate=100; //should fail
            Console.WriteLine("Rate after Setting to 100:" + account4.InterestRate);



            // account4.SetInterestRate(11); //should work

            account4.InterestRate = 11;  //calls set with value = 11
            
            Console.WriteLine("Rate after Setting to 11:" + account4.InterestRate ); //calls get


            Console.WriteLine($"Current Name:{account4.Name}");
            account4.Name="Santosh Singh"; //should fail
            Console.WriteLine($"Name after change to Santosh Singh: {account4.Name}");
            account4.Name="Sanjay Mall"; //should work
            Console.WriteLine($"Name after change to Sanjay Mall: {account4.Name}");



        }

        private static void TestAccount(BankAccount account)
        {
            account.ShowInfo();

            account.Deposit(1000);
            account.ShowInfo();

            account.Deposit(-1);
            account.ShowInfo();

            account.Withdraw(1000, "wrong-password");
            account.ShowInfo();

            account.Withdraw(1000, "p@ss");
            account.ShowInfo();

            account.CreditInterest();
            account.ShowInfo();
            Console.WriteLine("----------------------------------");
            Console.WriteLine(); //empty line
        }
    }

   
}
