using ConceptArchitect.Finance.Exceptions;

namespace ConceptArchitect.Finance.Repositories.ArrayRepository;


public class ArrayAccountRepository : IAccountRepository
{
    BankAccount[] accounts = new BankAccount[50]; //only 50 possible for now.
    int maxId = 0;
    int totalAccounts = 0;

    public BankAccount GetById(int accountNumber)
    {
        if (accountNumber < 1 || accountNumber > maxId || accounts[accountNumber] == null)
            throw new InvalidAccountException(accountNumber);
        else
            return accounts[accountNumber];
    }

    public void AddAccount(BankAccount account)
    {
        maxId = account.AccountNumber;
        accounts[account.AccountNumber] = account;
        totalAccounts++;
    }

    public void Remove(int accountNumer)
    {
        accounts[accountNumer] = null;
        totalAccounts--;
    }

    public IEnumerable<BankAccount> GetAll()
    {
        BankAccount[] result = new BankAccount[totalAccounts];
        int index = 0;
        for (var i = 1; i <= maxId; i++)
        {
            if (accounts[i] != null)
            {
                result[index++] = accounts[i];
            }
        }

        return result;

    }
    public void Save(BankAccount account){}

}