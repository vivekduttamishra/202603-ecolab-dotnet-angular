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

    public double InterestRate { get; set; }

    int lastId = 0;

    BankAccount[] accounts = new BankAccount[50]; //only 50 possible for now.

    public Bank(string name, double interestRate)
    {
        Name = name;
        InterestRate = interestRate;
    }

    public int OpenAccount(string accountType, string name, string password, int amount)
    {
        //we will ignore accountType for now.
        //step 1. generate account number
        var accountNumber = ++lastId;

        //step 2. create account
        var account = new BankAccount(accountNumber, name, password, amount);

        //step 3. add the account to accounts collection
        accounts[accountNumber] = account;

        //step 4. return 
        return accountNumber;
    }

    BankAccount GetAccount(int accountNumber)
    {
        if(accountNumber<1 || accountNumber>lastId || accounts[accountNumber]==null)
            return null;
        else
            return accounts[accountNumber];
    }

    public double CloseAccount(int accountNumber, string password)
    {
        //step1 get the account
       
        var account = GetAccount(accountNumber);

        if(account==null) //already closed
            return double.NaN;


        //step2 remove it from accounts
        if (account.Authenticate(password))
        {
            accounts[accountNumber] = null; //removed
            //step3. return the account balance;
            return account.Balance;

        }
        else
        {
            return double.NaN; 
        }

    }

    public bool Withdraw(int accountNumber, int amount, string password)
    {
        
        var account= GetAccount(accountNumber);

        if(account==null)
            return false;

        return account.Withdraw(amount,password);


    }


    public bool Deposit(int accountNumber, int amount)
    {
        var account = GetAccount(accountNumber);
        if(account==null)
            return false;
        
        return account.Deposit(amount);
    }

    public bool Transfer(int srcAccount, int amount, string password, int targetAccount)
    {
        //DO IT

        return false;
    }

    public void CreditInterest()
    {
        //DO IT: Pass one month interst to each account

    }

    public string GetAccounts()
    {
        //DO IT: RETURN INFORMATION ABOUT EACH ACCOUNT
        return null;
    }
}