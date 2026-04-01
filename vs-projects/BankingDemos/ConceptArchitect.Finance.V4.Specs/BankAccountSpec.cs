namespace ConceptArchitect.Finance.V4.Specs;

using System;
using ConceptArchitect.Finance;
using ConceptArchitect.Finance.Exceptions;
using Xunit.Sdk;

public class BankAccountSpec
{


    string password = "p@ss";
    string name = "Test Account";
    int amount = 20000;
    int accountNumber = 1;

    double interestRate = 12;
    BankAccount account;
    BankAccount currentAccount;


  
    public BankAccountSpec()
    {
        account = new CurrentAccount(accountNumber, name, password, amount);
    }


    private void AssertBalanceUnchanged()
    {
        Assert.Equal(amount, account.Balance);
    }

    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void New_BankAccountWillTake_Type_AccountNumber_Name_Password()
    {
        BankAccount account = new CurrentAccount(accountNumber, name, password, amount);

        Assert.Equal(accountNumber, account.AccountNumber);
        Assert.Equal(name, account.Name);
        Assert.Equal(amount, account.Balance);

    }


    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Authenticate_ValidatesWithCorrectPassword()
    {
        account.Authenticate(password);
        //if the code worked test passed.
    }

    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Authenticate_FailsWithInCorrectPassword()
    {
        //account.Authenticate is a void function
        //Assert.False(account.Authenticate("wrong-password"));
        try
        {
            account.Authenticate("wrong-password");
            //Test Failed.
            Assert.Fail("Expected Exception 'InvalidCredentialsException' was not thrown");
        }
        catch (InvalidCredentialsException ex)
        {
            //Test Passed.
            Assert.Equal(account.AccountNumber, ex.AccountNumber);
        }


    }


    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Deposit_FailsForIncorrectAmount()
    {
        Assert.Throws<InvalidDenominationException>(()=> account.Deposit(-1));
        AssertBalanceUnchanged();
    }

    [Fact(
    // Skip = "Not Yet Implemented"
    )]
    public void Deposit_SucceedsWithPositiveAmount()
    {
        account.Deposit(1);
        Assert.Equal(amount+1, account.Balance);
        
    }



    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Withdrw_FailsForNegativeAmount()
    {
        Assert.Throws<InvalidDenominationException>(()=> account.Withdraw(-1, password));
        AssertBalanceUnchanged();

    }


    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Withdraw_FailsForInvalidPassword()
    {
        Assert.Throws<InvalidCredentialsException>(()=> account.Withdraw(1, "invalid-password"));
        AssertBalanceUnchanged();

    }







   



}

