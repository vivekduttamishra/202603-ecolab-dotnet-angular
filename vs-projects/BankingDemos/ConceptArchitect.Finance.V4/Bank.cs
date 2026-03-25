namespace ConceptArchitect.Finance;

using System;
using ConceptArchitect.Finance.Exceptions;

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
        var account = new SavingsAccount(accountNumber, name, password, amount);

        //step 3. add the account to accounts collection
        accounts[accountNumber] = account;

        //step 4. return 
        return accountNumber;
    }

    BankAccount GetAccount(int accountNumber)
    {
        if(accountNumber<1 || accountNumber>lastId || accounts[accountNumber]==null)
            throw new InvalidAccountException(accountNumber);
        else
            return accounts[accountNumber];
    }

    public double CloseAccount(int accountNumber, string password)
    {
        //step1 get the account
       
        var account = GetAccount(accountNumber);
        account.Authenticate(password);
        accounts[accountNumber] = null; //removed
        return account.Balance;
    }

    public void Withdraw(int accountNumber, int amount, string password)
    {
        
        var account= GetAccount(accountNumber);

        account.Withdraw(amount,password);
    }


    public void Deposit(int accountNumber, int amount)
    {
        var account = GetAccount(accountNumber);
        account.Deposit(amount);
    }

    public void Transfer(int sourceAccountNumber, int amount, string password, int targetAccountNumber)
    {
        //DO IT
        var sourceAccount = GetAccount(sourceAccountNumber);

        var targetAccount=GetAccount(targetAccountNumber);

        sourceAccount.Withdraw(amount,password);

        targetAccount.Deposit(amount);
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

   public  string GetInfo(int accountNumber, string password)
    {
        var account = GetAccount(accountNumber);
        account.Authenticate(password);
        return account.ToString();

    }
}