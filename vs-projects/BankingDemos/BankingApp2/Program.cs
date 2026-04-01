using System;
using ConceptArchitect.Finance;
using ConceptArchitect.Finance.Firmeware;
using ConceptArchitect.Finance.Repositories.ArrayRepository;
using ConceptArchitect.Finance.Repositories.Sql;
class Program
{
    static void Main()
    {

        var iciciBank = new Bank("ICICI", 12, new SqlAccountRepository());
        var idfcBank = new Bank("IDFC", 12, new ArrayAccountRepository());

        //var a1 = iciciBank.OpenAccount("SavingsAccount", "Vivek Dutta Mishra", "p@ss", 20000);
        //var a2 = iciciBank.OpenAccount("CurrentAccount", "Sanjay Mall", "p@ss", 20000);
        //var a3 = iciciBank.OpenAccount("OverdraftAccount", "Prabhat Singh", "p@ss", 20000);
       
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