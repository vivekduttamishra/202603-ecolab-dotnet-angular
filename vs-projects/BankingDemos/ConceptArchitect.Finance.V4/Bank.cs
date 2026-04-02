namespace ConceptArchitect.Finance;

using System;
using ConceptArchitect.Finance.Exceptions;
using ConceptArchitect.Finance.Repositories;
using ConceptArchitect.Finance.Repositories.ArrayRepository;

public class AccountInfo
{
    public AccountInfo(BankAccount account)
    {
        AccountType=account.GetType().Name;
        AccountNumber=account.AccountNumber;
        Name=account.Name;
        Balance=account.Balance;
    }

    public AccountInfo()
    {
        
    }

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

    //ArrayAccountRepository repository=new ArrayAccountRepository();
    //ListAccountRepository repository=new ListAccountRepository();

    IAccountRepository repository;



    public Bank(string name, double interestRate, IAccountRepository repository)
    {
        Name = name;
        InterestRate = interestRate;
        this.repository=repository;

       
    }

    public IAccountFactory AccountFactory { get; set; } = new SmartAccountFactory();    



    public int OpenAccount(string accountType, string name, string password, double amount)
    {
        //we will ignore accountType for now.
        //step 1. generate account number
        var accountNumber = ++lastId;

        //step 2. create account

       
        var account = AccountFactory.Create(accountType,accountNumber, name, password, amount);

       


        //step 3. add the account to accounts collection
        //accounts[accountNumber] = account;
        repository.AddAccount(account);
        //repository.Save(account);

        //step 4. return 
        return account.AccountNumber;
    }

   

    public double CloseAccount(int accountNumber, string password)
    {
        //step1 get the account
       
        //var account = GetAccount(accountNumber);
        var account = repository.GetById(accountNumber);

        account.Authenticate(password);
        //accounts[accountNumber] = null; //removed

        repository.Remove(accountNumber);
        repository.Save(null); //save everything

        return account.Balance;
    }

    public void Withdraw(int accountNumber, int amount, string password)
    {
        
        //var account= GetAccount(accountNumber);
        var account = repository.GetById(accountNumber);

        account.Withdraw(amount,password);
        repository.Save(account);
    }


    public void Deposit(int accountNumber, int amount)
    {
        //var account = GetAccount(accountNumber);
        var account = repository.GetById(accountNumber);
        account.Deposit(amount);
        repository.Save(account);
    }

    public void Transfer(int sourceAccountNumber, double amount, string password, int targetAccountNumber)
    {
        //DO IT
        var sourceAccount = repository.GetById(sourceAccountNumber);

        var targetAccount=repository.GetById(targetAccountNumber);


        sourceAccount.Withdraw(amount,password);

        targetAccount.Deposit(amount);
        repository.Save(sourceAccount);
        repository.Save(targetAccount);
    }

    public int CreditInterest()
    {
        //DO IT: Pass one month interst to each account
        int creditedAccounts=0;
        // for(int i=1;i<=lastId;i++)
        // {
        //     if(accounts[i]!=null){
        //         accounts[i].CreditInterest(InterestRate);
        //         creditedAccounts++;
        //     }
        // }

        var accounts = repository.GetAll();
        var count=0;
        foreach(var account  in accounts)
        {
            
            account.CreditInterest(InterestRate);
            repository.Save(account);
            count++;
        }

        return count;
    }

    public List<AccountInfo> GetAccounts()
    {
        //DO IT: RETURN INFORMATION ABOUT EACH ACCOUNT
        var info= new List<AccountInfo>();
        foreach(var account in repository.GetAll())
            info.Add(new AccountInfo(account));
        
        return info;
    }

   public AccountInfo  GetInfo(int accountNumber, string password)
    {
        var account = repository.GetById(accountNumber);
        account.Authenticate(password);
        return new AccountInfo(account);

    }
}