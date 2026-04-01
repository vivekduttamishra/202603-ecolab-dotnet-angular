




using ConceptArchitect.Finance.Exceptions;

namespace ConceptArchitect.Finance;

public abstract class BankAccount
{
    public BankAccount(int accountNumber, string name, string password, double amount)
    {
        //AccountType = accountType;
        AccountNumber = accountNumber;
        Name = name;
        Password = password;
        Balance = amount;
    }


    //public string AccountType { get; }
    public int AccountNumber { get; set; }
    public string Name { get; }
    public string Password { get; private set; }

    public double Balance { get; protected set; }

    public void Authenticate(string password)
    {
        if (this.Password != password)
            throw new InvalidCredentialsException(AccountNumber);
        //no news is good news
    }


    public void ChangePassword(string originalPassword, string newPassword)
    {
        Authenticate(originalPassword);
        Password=newPassword;
    }

    public virtual void CreditInterest(double interestRate)
    {
        Balance += Balance * interestRate / 1200;
    }

    public virtual void  Deposit(double amount)
    {
            ValidateAmount(amount);
            Balance += amount;
    }

    public abstract double EffectiveBalance{get;}

    private void ValidateAmount(double amount)
    {
        if(amount<=0)
            throw new InvalidDenominationException("Amount Must be Positive");
    }
    
    public virtual void Withdraw(double amount, string password)
    {
                
        ValidateAmount(amount);
        
        Authenticate(password); 

        if (amount > EffectiveBalance)
            throw new InsufficientBalanceException(AccountNumber, amount-EffectiveBalance);

        Balance -= amount;
    }

    public override string ToString()
    {
        return $"{this.GetType().Name} Number: {AccountNumber}\tName={Name}\tBalance={Balance}";
    }
}