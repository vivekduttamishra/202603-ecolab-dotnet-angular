namespace ConceptArchitect.Finance.Specs;

using ConceptArchitect.Finance;

public class BankAccountSpec
{


    string password="p@ss";
    string name="Test Account";
    int amount = 20000;
    int accountNumber=1;

    string accountType="SavingsAccount";
    BankAccount savingsAccount;
    BankAccount currentAccount;


    void AssertTransactionFailed(bool result, BankAccount account=null)
    {
        if(account==null)
            account=savingsAccount;
        Assert.False(result);
        Assert.Equal(amount, savingsAccount.Balance); //balance unchanged
    }

    void AssertTransactionSucceeded(bool result, double delta, BankAccount account=null)
    {
        if(account==null)
            account=savingsAccount;
        Assert.True(result);
        Assert.Equal(amount+delta, account.Balance,0.01);
    }

    public BankAccountSpec()
    {
        savingsAccount=new BankAccount(accountType,accountNumber,name,password, amount);
        currentAccount=new BankAccount("CurrentAccount",accountNumber,name,password, amount);
    }



    [Fact(
        //Skip = "Not Yet Implemented"
    )]
    public void New_BankAccountWillTake_Type_AccountNumber_Name_Password()
    {
        BankAccount account=new BankAccount(accountType,accountNumber,name,password,amount);

        Assert.Equal(accountNumber, account.AccountNumber);
        Assert.Equal(name, account.Name);
        Assert.Equal(amount, account.Balance);
        Assert.Equal(accountType, account.AccountType);
    }


    [Fact(
        //Skip = "Not Yet Implemented"
    )]
    public void Authenticate_ValidatesWithCorrectPassword()
    {
        Assert.True( savingsAccount.Authenticate(password) );
    }

    [Fact(
        //Skip = "Not Yet Implemented"
    )]
    public void Authenticate_FailsWithInCorrectPassword()
    {
        Assert.False(savingsAccount.Authenticate("wrong-password"));
    }


    [Fact(
        //Skip = "Not Yet Implemented"
    )]
    public void Deposit_FailsForIncorrectAmount()
    {
        //act
        bool result = savingsAccount.Deposit(-1);
        //assert
        AssertTransactionFailed(result);
    }

    [Fact(
       // Skip = "Not Yet Implemented"
    )]
    public void Deposit_SucceedsWithPositiveAmount()
    {
        var result = savingsAccount.Deposit(1);

        //assert
        AssertTransactionSucceeded(result,1);
    }
    [Fact(
        //Skip = "Not Yet Implemented"
    )]
    public void Withdrw_FailsForNegativeAmount()
    {
        var result = savingsAccount.Withdraw(-1, password);

        //assert
        AssertTransactionFailed(result);
    }
    [Fact(
        //Skip = "Not Yet Implemented"
    )]
    public void Withdraw_FailsForInvalidPassword()
    {
        var result = savingsAccount.Withdraw(1, "invalid-password");
        //assert
        AssertTransactionFailed(result);
    }
   
    [Fact(
        Skip = "Test No More required"
    )]
    public void Withdraw_SucceedsForHappyPath()
    {
        var result=currentAccount.Withdraw(1,password);

        AssertTransactionSucceeded(result,-1,currentAccount);
    }


    [Fact(

    )]
    public void WithdrawFailsForSavingsAccountIfMinBalanceIsNotMet()
    {
        
        var result = savingsAccount.Withdraw(amount-savingsAccount.MinBalance+1, password);

        AssertTransactionFailed(result);

    }


    [Fact(

    )]
    public void WithdrawSucceedsForSavingsAccountIfForUptoMinBlance()
    {
        
        var result = currentAccount.Withdraw(amount-savingsAccount.MinBalance, password);

        AssertTransactionSucceeded(result, -(amount-savingsAccount.MinBalance),currentAccount);

    }
    [Fact(

    )]
    public void WithdrawFailsForCurrentAccountIfAmountMoreThanBalance()
    {
        
        var result = currentAccount.Withdraw(amount+1, password);

        AssertTransactionFailed(result,currentAccount);

    }


    [Fact(

    )]
    public void WithdrawSucceedsForCurrentAccountIfForUptoBalance()
    {
        
        var result = currentAccount.Withdraw(amount, password);

        AssertTransactionSucceeded(result, -amount, currentAccount);

    }


    [Fact(
       // Skip = "Not Yet Implemented"
    )]
    public void CreditInterst_CreditsOneMonthInterestForSavingsAccount()
    {
        var expectedInterest = amount*BankAccount.InterestRate/1200;

        savingsAccount.CreditInterest();

        AssertTransactionSucceeded(true,expectedInterest);

    }
    [Fact(
       // Skip = "Not Yet Implemented"
    )]
    public void CreditInterst_CreditsNoInterestForCurrentAccount()
    {
        var expectedInterest = amount*BankAccount.InterestRate/1200;

       currentAccount.CreditInterest();

        AssertTransactionSucceeded(true,0,currentAccount);

    }



}

