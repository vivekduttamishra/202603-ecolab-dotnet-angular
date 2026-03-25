using System;
using ConceptArchitect.Finance;
using ConceptArchitect.Finance.Firmeware;
class Program
{
    static void Main()
    {

        var iciciBank = new Bank("ICICI", 12);
        var idfcBank = new Bank("IDFC", 12);

        var a1 = iciciBank.OpenAccount("Savings", "Vivek Dutta Mishra", "p@ss", 20000);
        var a2 = iciciBank.OpenAccount("Current", "Sanjay Mall", "p@ss", 20000);
        var a3 = iciciBank.OpenAccount("Overdraft", "Prabhat Singh", "p@ss", 20000);
       
        var atm = new ATM(iciciBank);
        try
        {
            
            atm.Start();
        }catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine("Program Ends Normally");
    }
}