namespace ConceptArchitect.Finance.Repositories;

public interface IAccountRepository
{
    void AddAccount(BankAccount account);
    //BankAccount[] GetAll();

    IEnumerable<BankAccount> GetAll();
    BankAccount GetById(int accountNumber);
    void Remove(int accountNumer);
    void Save(BankAccount account);
}
