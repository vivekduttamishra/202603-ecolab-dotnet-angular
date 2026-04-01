namespace ConceptArchitect.Finance;

using System;
using ConceptArchitect.Finance.Exceptions;

public class AccountInfo
{
    public string AccountType { get; set; }
    public int AccountNumber { get; set; }  
    public string Name { get; set; }
    public double Balance { get; set; }
}


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

        accountBuilders["savings"]= (accountNumber, name, password, amount)=> new SavingsAccount(accountNumber,name,password, amount);
        accountBuilders["current"]= (accountNumber, name, password, amount)=> new CurrentAccount(accountNumber,name,password, amount);
        accountBuilders["od"]= (accountNumber, name, password, amount)=> new OverdraftAccount(accountNumber,name,password, amount);

    }

    public void AddAccountBuilder(string accountType, Func<int,string,string,double,BankAccount> accountBuilder)
    {
        accountBuilders[accountType]=accountBuilder;
    }

    Dictionary<string, Func<int,string,string,double,BankAccount>> accountBuilders=new Dictionary<string, Func<int,string,string,double,BankAccount>>();


    public int OpenAccount(string accountType, string name, string password, double amount)
    {
        //we will ignore accountType for now.
        //step 1. generate account number
        var accountNumber = ++lastId;

        //step 2. create account

        if(!accountBuilders.ContainsKey(accountType.ToLower()))
            throw new BankingException(0, "Invalid Account Type: "+accountType);

        var accountBuilder = accountBuilders[accountType.ToLower()];
        //var account = new CurrentAccount(accountNumber, name, password, amount);
        var account =accountBuilder(accountNumber, name, password, amount);


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

    public void Transfer(int sourceAccountNumber, double amount, string password, int targetAccountNumber)
    {
        //DO IT
        var sourceAccount = GetAccount(sourceAccountNumber);

        var targetAccount=GetAccount(targetAccountNumber);

        sourceAccount.Withdraw(amount,password);

        targetAccount.Deposit(amount);
    }

    public int CreditInterest()
    {
        //DO IT: Pass one month interst to each account
        int creditedAccounts=0;
        for(int i=1;i<=lastId;i++)
        {
            if(accounts[i]!=null){
                accounts[i].CreditInterest(InterestRate);
                creditedAccounts++;
            }
        }

        return creditedAccounts;
    }

    public string GetAccounts()
    {
        //DO IT: RETURN INFORMATION ABOUT EACH ACCOUNT
        return null;
    }

   public AccountInfo  GetInfo(int accountNumber, string password)
    {
        var account = GetAccount(accountNumber);
        account.Authenticate(password);
        return new AccountInfo
        {
            AccountType= account.GetType().Name,
            AccountNumber=account.AccountNumber,
            Name= account.Name,
            Balance=account.Balance            
        };

    }
}