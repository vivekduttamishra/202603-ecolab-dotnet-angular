

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

            var account3 = new BankAccount();

            //forgot to call
            //account3.CreateAccount(3, "Sanjay", "password", 40000, 12);

            TestAccount(account3);


            var account4=new BankAccount(4, "Santosh", "pass", 20000, 12);
           
           //        account4.CreateAccount(5, "Santosh", "pass", 30000, 12);

            TestAccount(account4);
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
