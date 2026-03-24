namespace ConceptArchitect.Finance;

using ConceptArchitect.Finance;

public class CurrentAccount : BankAccount
{
    public CurrentAccount(int accountNumber, string name, string password, double amount)
        :base(accountNumber, name, password,amount)
    {
    }

    public override void CreditInterest(double interestRate)
    {
        //DO NOTHING
        //no interest will be credited.
    }
}