namespace ConceptArchitect.Finance.Specs;

using ConceptArchitect.Finance;

public class BankAccountSpec
{


    string password = "p@ss";
    string name = "Test Account";
    int amount = 20000;
    int accountNumber = 1;

    double interestRate=12;
    BankAccount account;
    BankAccount currentAccount;


    void AssertTransactionFailed(bool result)
    {

        Assert.False(result);
        Assert.Equal(amount, this.account.Balance); //balance unchanged
    }

    void AssertTransactionSucceeded(bool result, double delta)
    {

        Assert.True(result);
        Assert.Equal(amount + delta, account.Balance, 0.01);
    }

    public BankAccountSpec()
    {
        account = new BankAccount(accountNumber, name, password, amount);
    }



    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void New_BankAccountWillTake_Type_AccountNumber_Name_Password()
    {
        BankAccount account = new BankAccount(accountNumber, name, password, amount);

        Assert.Equal(accountNumber, account.AccountNumber);
        Assert.Equal(name, account.Name);
        Assert.Equal(amount, account.Balance);

    }


    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Authenticate_ValidatesWithCorrectPassword()
    {
        Assert.True(account.Authenticate(password));
    }

    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Authenticate_FailsWithInCorrectPassword()
    {
        Assert.False(account.Authenticate("wrong-password"));
    }


    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Deposit_FailsForIncorrectAmount()
    {
        //act
        bool result = account.Deposit(-1);
        //assert
        AssertTransactionFailed(result);
    }

    [Fact(
    // Skip = "Not Yet Implemented"
    )]
    public void Deposit_SucceedsWithPositiveAmount()
    {
        var result = account.Deposit(1);

        //assert
        AssertTransactionSucceeded(result, 1);
    }
    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Withdrw_FailsForNegativeAmount()
    {
        var result = account.Withdraw(-1, password);

        //assert
        AssertTransactionFailed(result);
    }
    [Fact(
    //Skip = "Not Yet Implemented"
    )]
    public void Withdraw_FailsForInvalidPassword()
    {
        var result = account.Withdraw(1, "invalid-password");
        //assert
        AssertTransactionFailed(result);
    }







    [Fact(
    // Skip = "Not Yet Implemented"
    )]
    public void CreditInterst_CreditsOneMonthInterest()
    {
        var expectedInterest = amount * interestRate / 1200;

        account.CreditInterest(interestRate);

        AssertTransactionSucceeded(true, expectedInterest);

    }



}

