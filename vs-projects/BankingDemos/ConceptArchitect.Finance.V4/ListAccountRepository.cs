using ConceptArchitect.Finance.Exceptions;

namespace ConceptArchitect.Finance.Repositories.ArrayRepository;

public class ListAccountRepository : IAccountRepository
{
    //BankAccount[] accounts = new BankAccount[50]; //only 50 possible for now.
    List<BankAccount> accounts = new List<BankAccount>();
    int maxId=0;
    int totalAccounts=0;
   


    public void AddAccount(BankAccount account)
    {
        maxId= account.AccountNumber;
        //accounts[account.AccountNumber]=account;
        accounts.Add(account);
        
    }

    public BankAccount GetById(int accountNumber)
    {
        if(accountNumber<1 || accountNumber>maxId || accounts[accountNumber-1]==null)
            throw new InvalidAccountException(accountNumber);
        else
            return accounts[accountNumber-1];
    }

  

    public void Remove(int accountNumber)
    {
        //accounts[accountNumer]=null;
        var account = GetById(accountNumber);
        accounts.Remove(account);
       
    }

    public IEnumerable<BankAccount> GetAll()
    {
        return accounts;
        
    }

    public void Save(BankAccount account){}

}