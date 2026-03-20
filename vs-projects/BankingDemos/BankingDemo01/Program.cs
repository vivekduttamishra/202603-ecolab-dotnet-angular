using System;
using ConceptArchitect.Finance;
using ConceptArchitect.Finance.Firmeware;
class Program
{
    static void Main()
    {

       var bank = new Bank("ICICI",12);

       var a1= bank.OpenAccount("Savings", "Vivek Dutta Mishra","p@ss", 20000);
       var a2= bank.OpenAccount("Current", "Sanjay Mall","p@ss", 20000);
       var a3= bank.OpenAccount("Overdraft", "Prabhat Singh","p@ss", 20000);

       var atm= new ATM(bank);

       atm.Start();
   


    }
}