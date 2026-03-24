
namespace ConceptArchitect.Finance;

public class OverdraftAccount : BankAccount
{
    public double OdLimit { get; private set; }

    public OverdraftAccount(int accountNumber, string name, string password, double amount)
        : base(accountNumber, name, password, amount)
    {
        AdjustOdLimit();
    }

    public override bool Deposit(double amount)
    {
        var result = base.Deposit(amount);
        AdjustOdLimit();
        return result;
    }

    private void AdjustOdLimit()
    {
        if (Balance / 10 > OdLimit)
            OdLimit = Balance / 10;
    }

    public override void CreditInterest(double interestRate)
    {
        base.CreditInterest(interestRate);
        AdjustOdLimit();
    }

    public override double EffectiveBalance { get{ return Balance+OdLimit; }}

    public override bool Withdraw(double amount, string password)
    {

        if(amount>Balance)
        {
            var od = (amount-Balance)*0.05;
            amount+=od;
        }

        return base.Withdraw(amount, password);
    }
    
}