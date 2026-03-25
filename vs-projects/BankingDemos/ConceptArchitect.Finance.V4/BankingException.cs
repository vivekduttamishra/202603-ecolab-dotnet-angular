namespace ConceptArchitect.Finance.Exceptions;

public class BankingException : Exception
{
    public int AccountNumber { get; private set; }

    public BankingException(int accountNumber, string message)
        :base(message)
    {
        AccountNumber= accountNumber;
    }

}

//Special BankingExceptions

public class InvalidCredentialsException : BankingException
{
    public InvalidCredentialsException(int accountNumber, string message="Invalid Credentials") : base(accountNumber, message)
    {
    }
}

public class InvalidAccountException : BankingException
{
    public InvalidAccountException(int accountNumber, string message="Invalid Account") : base(accountNumber, message)
    {
    }
}


public class InsufficientBalanceException : BankingException
{
    public InsufficientBalanceException(int accountNumber,double deficit, string message="Insufficient Balance") 
        : base(accountNumber, message)
    {
        Deficit=deficit;
    }

    public double Deficit { get; private set; }
}

public class InvalidDenominationException : Exception
{
    public InvalidDenominationException(string message="Invalid Denomination"):base(message)
    {
        
    }
}