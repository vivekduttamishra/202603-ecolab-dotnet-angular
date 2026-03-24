
namespace ConceptArchitect.Finance;

public class OverdraftAccount : BankAccount
{
    public double OdLimit{get; private set;}

    public OverdraftAccount(int accountNumber, string name, string password, double amount) 
        : base(accountNumber, name, password, amount)
    {
        OdLimit=amount/10;
    }
}