using System.Formats.Asn1;
using ConceptArchitect.Finance;

namespace TestBankingV1;

public class BankAccountTests
{
    string password = "p@ss";
    int amount = 20000;
    string firstName="Test";
    string lastName="Accout";
    string name;
    
    BankAccount a1;


    void AssertTransactionSucceed(bool result, double delta)
    {
        Assert.True(result);
        Assert.Equal(amount+delta, a1.Balance,0.01);
    }

    void AssertTransactionFailed(bool result)
    {
        Assert.False(result);
        Assert.Equal(amount, a1.Balance); //balance remain unchanged.
    }


    public BankAccountTests()
    {
        name = $"{firstName} {lastName}";
        a1 = new BankAccount(1, name, password, amount);
        
    }


    

    [Fact]
    public void WithdrawShouldSucceedForHappyPath()
    {
        //Arrange

        //Act
        var result = a1.Withdraw(1, password);
        //Console.WriteLine(result);

        //Assert
        // Assert.True(result);
        // Assert.Equal(amount-1, a1.Balance, 0.01);

        AssertTransactionSucceed(result, -1);
    }

    [Fact]

    public void WithdrawShouldFailForInvalidPassword()
    {
        var result = a1.Withdraw(1, "wrong-password");
        
        //Assert.False(result);   //only checks result
        AssertTransactionFailed(result); //checks both result and balance

    }


    [Fact]
    public void CreditInterest_CreditsInterestForOneMonth()
    {
        //arrange
        var expectedInterest= amount* BankAccount.InterestRate/1200;

        //act
        a1.CreditInterest();

        //assert
        //Assert.Equal(expectedAmount, a1.Balance, 0.01);     

        AssertTransactionSucceed(true,expectedInterest)  ; 
    


    }


    [Fact]
    public void Withdraw_FailsForInsufficientBalance()
    {
        AssertTransactionFailed( a1.Withdraw(amount+1,password));
    }
    [Fact]
    public void Withdraw_FailsForInvalidAmount()
    {
        AssertTransactionFailed( a1.Withdraw(-1,password));
    }

    [Fact]
    public void Deposit_FailsForInvalidAmount()
    {
        AssertTransactionFailed(a1.Deposit(-1));
    }

    [Fact]
    public void Deposit_SucceedsForValidAmount()
    {
        AssertTransactionSucceed(a1.Deposit(1),1);
    }

   
    [Fact(
    //    Skip ="Not Yet Implemented"
    )]
    public void Info_IncludesAccountType_AccountNumber_AND_BALANCE()
    {
        //ARRANGE
        //ACT
        
        Assert.Contains("Account Number=1", a1.Info);
        Assert.Contains($"Balance={amount}", a1.Info);
        Assert.Contains($"Name={name}", a1.Info);


       
    }

    [Fact]
    public void Info_DoesntIncludePassword()
    {
         //ARRANGE
         //ACT MERGED WITH ASSERT


        //ASSERT
        Assert.DoesNotContain("Password",a1.Info);

        
    }


}
