

using ConceptArchitect.Finance;

namespace BankAccountDemo01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var account = new BankAccount();
            account.accountNumber = 1;
            account.name = "Vivek Dutta Mishra";
            account.password = "p@ss";
            account.balance = 50000.0;
            account.interestRate = 12.0;

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


            //no deposit done but amount changed
            account.balance += 200000;
            account.ShowInfo();

            account.Withdraw(100000, "wrong-password");
            account.ShowInfo();
            //I don't know your password 
            //But I can change it
            account.password = "any-password";
            account.Withdraw(100000, "any-password");
            account.ShowInfo();





        }
    }

   
}
