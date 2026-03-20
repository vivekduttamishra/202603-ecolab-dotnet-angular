namespace ConceptArchitect.Finance;
using System;


public class Bank
{
    // string name;

    // public string Name
    // {
    //     get{ return name; }
    //     set{name=value;}
    // }

    public string Name { get; }

    public double InterestRate{ get; set; }

    int lastId;

    BankAccount [] accounts = new BankAccount[50]; //only 50 possible for now.

    public Bank(string name, double interestRate)
    {
        this.Name = name;
        InterestRate=interestRate;
    }

    

  
}