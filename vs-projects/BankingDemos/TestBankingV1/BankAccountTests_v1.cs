using System.Formats.Asn1;
using ConceptArchitect.Finance;

namespace TestBankingV1;

public class BankAccountTestsV1
{

    

    [Fact]
    public void WithdrawShouldSucceedForHappyPath()
    {
        //Arrange
        var password = "p@ss";
        var amount = 20000;
        var a1 = new BankAccount(1, "Any Name", password, amount);

        //Act
        var result = a1.Withdraw(1, password);
        //Console.WriteLine(result);

        //Assert
        Assert.True(result);
        Assert.Equal(amount-1, a1.Balance, 0.01);
    }

    [Fact]

    public void WithdrawShouldFailForInvalidPassword()
    {
        var password = "p@ss";
        var amount = 20000;
        var a1 = new BankAccount(1, "Any Name", password, amount);
        var result = a1.Withdraw(1, "wrong-password");
        //Console.WriteLine(result);
        Assert.False(result);
    }


    [Fact]
    public void CreditInterest_CreditsInterestForOneMonth()
    {
        //arrange
        var password = "p@ss";
        var amount = 20000;
        var a1 = new BankAccount(1, "Any Name", password, amount);
        var expectedAmount= amount+amount* BankAccount.InterestRate/1200;

        //act
        a1.CreditInterest();

        //assert
        Assert.Equal(expectedAmount, a1.Balance, 0.01);        
    


    }

   
    [Fact(
    //    Skip ="Not Yet Implemented"
    )]
    public void Info_IncludesAccountType_AccountNumber_AND_BALANCE()
    {
        //ARRANGE
         var password = "p@ss";
        var amount = 20000;
        var name= "Test Name";
        var a1 = new BankAccount(1, name, password, amount);

        //ACT
        
        Assert.Contains("Account Number=1", a1.Info);
        Assert.Contains($"Balance={amount}", a1.Info);
        Assert.Contains($"Name={name}", a1.Info);


       
    }

    [Fact]
    public void Info_DoesntIncludePassword()
    {
         //ARRANGE
        var password = "p@ss";
        var amount = 20000;
        var name= "Test Name";
        var a1 = new BankAccount(1, name, password, amount);

        //ACT MERGED WITH ASSERT


        //ASSERT
        Assert.DoesNotContain("Password",a1.Info);

        
    }


}
