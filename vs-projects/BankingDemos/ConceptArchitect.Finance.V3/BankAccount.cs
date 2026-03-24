




namespace ConceptArchitect.Finance;

public class BankAccount
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
    public int AccountNumber { get; }
    public string Name { get; }
    public string Password { get; }
   
    public double Balance { get; protected set; }

    public bool Authenticate(string password)
    {
        return this.Password == password;
    }

    public virtual void CreditInterest(double interestRate)
    {
        Balance += Balance * interestRate / 1200;
    }

    public virtual bool Deposit(double amount)
    {
        if (amount > 0)
            Balance += amount;
        return amount > 0;
    }

    public virtual bool Withdraw(double amount, string password)
    {
        if (amount <= 0)
            return false;
        if (!Authenticate(password))
            return false;

        if (amount > Balance)
            return false;

        Balance -= amount;
        return true;
    }

}