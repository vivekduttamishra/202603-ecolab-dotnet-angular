
namespace ConceptArchitect.Finance.Specs;

using ConceptArchitect.Finance;

public class OverdraftAccountSpecs
{

    OverdraftAccount account;
    string name = "Overdraft Account";
    string password = "p@ss";

    int accountNumber = 1;

    double amount = 20000;

    public OverdraftAccountSpecs()
    {
        account=new OverdraftAccount(accountNumber,name,password,amount);
    }


    [Fact(
        //Skip = "Not Yet Implemented"
    )]
    public void New_AccountShouldHaveOdLimitEqualTo10PercentOfInitialDeposit()
    {
        Assert.Equal(amount/10, account.OdLimit, 0.01);
    }

    [Fact(
       // Skip = "Not Yet Implemented"
    )]
    public void Deposit_ShouldUpdateOdLimitIfItCrossesHistoricMaxBalance()
    {
        //arrange
        var currentOdLimit= account.OdLimit;
        var depositAmount= 10000;
        var expetedNewOdLimit = currentOdLimit + depositAmount/10;

        //act
        account.Deposit(depositAmount);

        //assert
        Assert.Equal(expetedNewOdLimit, account.OdLimit,0.01);

    }

    [Fact(
        Skip = "Not Yet Implemented"
    )]
    public void Deposit_ShouldNotUpdateOdLimitIfItDoesntCrossesHistoricMaxBalance()
    {
        //Arrange
        account.Deposit(10000); //we changed the historic max balance
        var odLimitAtHistoricMaxBalance= account.OdLimit;
        account.Withdraw(10000, password); //balance reduced for historic max balance

        //act
        account.Deposit(5000); //new deposit doesn't reach historic max balance;

        //new deposit shouldn't update odLimt again

        Assert.Equal(odLimitAtHistoricMaxBalance, account.OdLimit,0.01);

    }

    [Fact(
        Skip = "Not Yet Implemented"
    )]
    public void CreditInterest_ShouldUpdateOdLimitIfItCrossesHistoricMaxBalance()
    {
        var originalOdLimit = account.OdLimit;

        account.CreditInterest(12); //we got 1% interest.

        var expectedOdLimit = (amount*1.01)/10;

        Assert.Equal(expectedOdLimit, account.OdLimit,0.01);

    }

    [Fact(
        Skip = "Not Yet Implemented"
    )]
    public void CreditInterest_ShouldNotUpdateOdLimitIfItDoesntCrossesHistoricMaxBalance()
    {
        //arrange
        account.Deposit( amount/2); //added 50% more money
        var odLimit= account.OdLimit;
        account.Withdraw(amount/2,password); //balance reduced to original value

        //act
        account.CreditInterest(12); //will increase amount by 1%. doesn't reach historic max balance

        //assert

        Assert.Equal(odLimit, account.OdLimit, 0.01);

    }

    [Fact(
        Skip = "Not Yet Implemented"
    )]
    public void Withdraw_ShouldNotChangeOdLimt()
    {
        var odLimit = account.OdLimit;

        //act
        account.Withdraw(amount,password);

        //assert
        Assert.Equal(odLimit, account.OdLimit,0.01);
    }



    [Fact(
        Skip = "Not Yet Implemented"
    )]
    public void Withdraw_ShouldFailForAmountGreaterThanBalancePlusOdLimt()
    {
        var result = account.Withdraw(amount+account.OdLimit+1, password );

        Assert.False(result);

        Assert.Equal(amount, account.Balance, 0.01);
    }

    [Fact(
        Skip = "Not Yet Implemented"
    )]
    public void Withdraw_ShouldSucceedForAmountUptoBalancePlusOdLimt()
    {
        var result = account.Withdraw(amount+account.OdLimit, password);

        Assert.True(result);

        Assert.True( account.Balance<0);

    }

    [Fact(
        Skip = "Not Yet Implemented"
    )]
    public void Withdraw_ShouldAddOdFeeOnOdAmount()
    {
        var maxAllowedLimit = amount+ account.OdLimit;  //20000+ 2000 = 22000
        var amountToWithdraw = amount+ account.OdLimit/2;  //20000+ 1000 = 21000
        var od= amount-amountToWithdraw;  // 20000 - 21000 = -1000
        var odFee = od*0.05; //5% of 1000 = -50
        var finalBalance = od + odFee; // = -1050

        //act
        var result = account.Withdraw(amountToWithdraw, password);

        //Assert
        Assert.True(result);
        Assert.Equal(finalBalance, account.Balance, 0.01);


    }

}