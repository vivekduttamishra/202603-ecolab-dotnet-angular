

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

            System.Console.WriteLine($"a1: {a1.Info}");
            System.Console.WriteLine($"a2: {a2.Info}");
           

            var success = a1.Transfer(500000,"pass1",a2);
            if(success)
                System.Console.WriteLine("Tranferred successfully");
            else
                System.Console.WriteLine("Transfer Failed");

            System.Console.WriteLine($"a1: {a1.Info}");
            System.Console.WriteLine($"a2: {a2.Info}");


        }

        private static void TestAccount(BankAccount account)
        {
            
        }
    }

   
}
