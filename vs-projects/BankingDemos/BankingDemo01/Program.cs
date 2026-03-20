using System;
using ConceptArchitect.Finance;
using ConceptArchitect.Finance.Firmeware;
class Program
{
    static void Main()
    {

        var bank = new Bank("ICICI", 12);

        var a1 = bank.OpenAccount("Savings", "Vivek Dutta Mishra", "p@ss", 20000);
        var a2 = bank.OpenAccount("Current", "Sanjay Mall", "p@ss", 20000);
        var a3 = bank.OpenAccount("Overdraft", "Prabhat Singh", "p@ss", 20000);

       // Production(bank);

       TestBank(bank);

    }

    private static void TestBank(Bank bank)
    {
        var balance=20000;   
        var correctPassword="p@ss";
        PrintTestResult( "Should Pass for right amount and right balance", bank.Withdraw(1, 1,correctPassword)==true);
        PrintTestResult( "Should pass for positive deposit", bank.Deposit(1,100)==true);
        PrintTestResult( "Should fail for insufficient balance", bank.Withdraw(1,balance+1,correctPassword)==false );
        //code will crash here
        PrintTestResult ("Should fail for invalid account number", bank.Withdraw(100,1,correctPassword)==false);
        //this code will never execute
        
        PrintTestResult( "Should Fail for wrong password", bank.Withdraw(1, 1,"wrong-password")==false);
    }

    private static void PrintTestResult(string message, bool condition)
    {
      System.Console.Write(message+":\t");
      if (condition)
      {
         Console.ForegroundColor=ConsoleColor.Green;
         System.Console.WriteLine("PASSED");
      }
      else
      {
         Console.ForegroundColor=ConsoleColor.Red;
         System.Console.WriteLine("FAILED");
      }

      Console.ResetColor();
    }

    private static void Production(Bank bank)
    {
        var atm = new ATM(bank);

        atm.Start();
    }
}