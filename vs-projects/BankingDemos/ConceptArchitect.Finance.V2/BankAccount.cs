




namespace ConceptArchitect.Finance;

public class BankAccount
{
    public BankAccount(string accountType, int accountNumber, string name, string password, int amount)
    {
        AccountType = accountType;
        AccountNumber = accountNumber;
        Name = name;
        Password = password;
        Balance = amount;
    }

    public static int InterestRate { get; set; } = 12;
    public string AccountType { get; }
    public int AccountNumber { get; }
    public string Name { get; }
    public string Password { get; }
    public int MinBalance { get;  }=5000;
    public int Balance { get; private set; }

    public bool Authenticate(string password)
    {
        return this.Password == password;
    }

    public void CreditInterest()
    {
        if(AccountType!="CurrentAccount")
            Balance += Balance * InterestRate / 1200;
    }

    public bool Deposit(int amount)
    {
        if (amount > 0)
            Balance += amount;
        return amount > 0;
    }

    public bool Withdraw(int amount, string password)
    {
        if (amount <= 0)
            return false;
        if (!Authenticate(password))
            return false;

         var maxWithdrawableAmount=Balance;
        if(AccountType=="SavingsAccount")
            maxWithdrawableAmount=Balance-MinBalance;

        if(amount>maxWithdrawableAmount)
            return false;
        
        Balance -= amount;
        return true;
    }

   
}