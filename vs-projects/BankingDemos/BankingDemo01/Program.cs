using System;
using ConceptArchitect.Finance;
class Program
{
    static void Main()
    {

        Console.WriteLine("Hello Banking!");
        var a1 = new BankAccount("Vivek Dutta Mishra", "pass1", 20000);
        Console.WriteLine(a1.Info);
    }
}