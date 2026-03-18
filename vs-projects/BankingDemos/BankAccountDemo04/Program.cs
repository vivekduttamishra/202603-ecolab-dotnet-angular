

using ConceptArchitect.Finance;
using System.Runtime.InteropServices;

namespace ConceptArchitect.Finance.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a1 = new BankAccount( "Vivek Dutta Mishra", "pass1", 20000);

            var a2 = new BankAccount( "Sanjay Mall", "pass2", 30000);

            a1.ShowInfo();
            a2.ShowInfo();

            //a1.InterestRate = 13;
            BankAccount.InterestRate = 13;

            a1.Deposit(1000); //changes only a1.balance      

            a1.ShowInfo();
            a2.ShowInfo();


        }

        private static void TestAccount(BankAccount account)
        {
            
        }
    }

   
}
