using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class BankingException : Exception
    {
        
        public BankingException():base("Banking Exception")
        {
           
        }

        public BankingException( string? message) : base(message)
        {
        }

        public BankingException(int accountNumber, string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected BankingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    public class InvalidAccountException: BankingException
    {
        public InvalidAccountException(int accountNumber, string message="Invalid Account"):
            base(message)
        {
            AccountNumber = accountNumber;
        }

        public int AccountNumber { get; }
    }


    public class InvalidCredentialsException : BankingException
    {
        public InvalidCredentialsException(string id, string message = "Invalid Credentials") :
            base(message)
        {
            Id = id;
        }

        public string Id { get; }
    }

    public class InvalidDenominationException : BankingException
    {
        public InvalidDenominationException( string message = "Invalid Denomination") :
            base( message)
        {

        }
    }

    public class InvalidAccountTypeException : BankingException
    {
        public InvalidAccountTypeException(string accountType, string message = "Invalid AccountType") :
            base(message)
        {
            AccountType = accountType;
        }

        public string AccountType { get; }
    }

    public class InsufficientBalanceException : BankingException
    {
        public InsufficientBalanceException(int accountNumber , double deficit, string message = "Invalid AccountType") :
            base( message)
        {
            AccountNumber = accountNumber;
            Deficit=deficit;
        }

        public int AccountNumber { get; }
        public double Deficit { get; }
    }


}
