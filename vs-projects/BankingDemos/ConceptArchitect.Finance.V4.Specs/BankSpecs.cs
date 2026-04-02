using System.Runtime.Serialization;
using ConceptArchitect.Finance.Exceptions;
using ConceptArchitect.Finance.Repositories.ArrayRepository;

namespace ConceptArchitect.Finance.V4.Specs;


public class BankSpecs
{
    Bank bank;
    double interestRate=12;
    string password="p@ss";
    double amount = 20000;
    int sa, ca, oda;
    public BankSpecs()
    {
        bank=new Bank("Bank Name",interestRate, new ListAccountRepository());

        sa= bank.OpenAccount("SavingsAccount","Test Name",password,amount);
        ca= bank.OpenAccount("CurrentAccount","Test Name",password,amount);
        oda= bank.OpenAccount("OverdraftAccount","Test Name",password,amount);
    }

    void AssertBalance(int accountNumber, double updatedBalance)
    {
        var info =bank.GetInfo(accountNumber,password);

        Assert.Equal(updatedBalance, info.Balance, 0.01);
    }

    void AssertBalanceUnchanged(int accountNumber)
    {
        AssertBalance(accountNumber,amount);
    }




    [Fact(
        //Skip ="Not Yet Implemented"
    )]
    public void OpenAccount_ReturnsUniqueIncreasingAccountNumber()
    {
        var a1 = bank.OpenAccount("SavingsAccount","Account1","pass",20000);
        var a2 = bank.OpenAccount("CurrentAccount","Account1","pass",20000);

        Assert.IsType<int>(a1);
        Assert.Equal(a1+1, a2);
    }


    [Fact]
    public void OpenAccount_CreatesSavingsAccountWhenSavingsTypeIsPassed()
    {
        var a1= bank.OpenAccount("SavingsAccount","Savings Account","p@ss", 20000);

        //how do I verify that a1 (which is int) is associated with SavingsAccount
        var info = bank.GetInfo(a1,"p@ss");
        
        Assert.Equal("SavingsAccount",info.AccountType);
   
    }

    [Fact]
    public void OpenAccount_CreatesCurrentAccountWhenCurrentTypeIsPassed()
    {
        var a1 = bank.OpenAccount("CurrentAccount","Current Account","p@ss",20000);

        var info = bank.GetInfo(a1, "p@ss");

        //Assert.Contains("CurrentAccount",info.ToString());
        Assert.Equal("CurrentAccount", info.AccountType);
    }
    [Fact]
    public void OpenAccount_CreatesOverdraftAccountWhenOdTypeIsPassed()
    {
        var a1 = bank.OpenAccount("OverdraftAccount","Overdraft Account","p@ss",20000);

        var info = bank.GetInfo(a1, "p@ss");

        Assert.Equal("OverdraftAccount",info.AccountType);
    }
    [Fact]
    public void OpenAccount_FailsForInvalidAccountType()
    {
        //Assert.Throws<BankingException>(()=> bank.OpenAccount("InvalidType","Current Account","p@ss",20000));

        //var account = bank.OpenAccount("InvaliType", "Any Name", password, amount);
        //var info = bank.GetInfo(account, password);

        //Assert.Equal("SavingsAccount", info.AccountType);

    }

    [Fact]
    public void Deposit_FailsForInvalidAccountNumber()
    {
        var invalidAccount = 1000;
        var ex= Assert.Throws<InvalidAccountException>(()=> bank.Deposit(invalidAccount,1));
    
        Assert.Equal(invalidAccount, ex.AccountNumber);
    }

    [Fact]
    public void Deposit_SucceedsForValidAccountNumber()
    {
        bank.Deposit(sa, 1);

        AssertBalance(sa, amount+1);
    }

    [Fact]
    public void Transfer_FailsForInvalidFromAccount()
    {
        var ex = Assert.Throws<InvalidAccountException>(()=>bank.Transfer(-1,1,password,sa));

        Assert.Equal(-1, ex.AccountNumber);
        AssertBalanceUnchanged(sa);        
    }

    [Fact]
    public void Transfer_FailsForInvalidToAccount()
    {
        var ex = Assert.Throws<InvalidAccountException>(()=>bank.Transfer(sa,1,password,-1));

        Assert.Equal(-1, ex.AccountNumber);
        AssertBalanceUnchanged(sa);        
    }

    [Fact]
    public void Transfer_FailsForInvalidPassword()
    {
        var ex = Assert.Throws<InvalidCredentialsException>(()=>bank.Transfer(sa,1,"wrong-password",ca));

        
        AssertBalanceUnchanged(sa);        
        AssertBalanceUnchanged(ca);        
    }
    [Fact]
    public void Transfer_FailsForInsufficientBalance()
    {
        var ex = Assert.Throws<InsufficientBalanceException>(()=>bank.Transfer(sa,amount+1,password,ca));

        
        AssertBalanceUnchanged(sa);        
        AssertBalanceUnchanged(ca);        
    }
    [Fact]
    public void Transfer_SucceedsOnHappyPath()
    {
        bank.Transfer(sa,1,password,ca);
        
        AssertBalance(sa, amount-1);
        AssertBalance(ca, amount+1);      
    }


    [Fact]
    public void CreditInterest_ShouldCreditInterestToSavingsAndOdAccount()
    {
        bank.CreditInterest();
        var updatedBalance= amount + amount*interestRate/1200;

        AssertBalance(sa, updatedBalance);
        AssertBalance(oda, updatedBalance);
       
    }
    [Fact]
    public void CreditInterest_ShouldNotCreditInterestToCurrentAccount()
    {
        bank.CreditInterest();
        var updatedBalance= amount + amount*interestRate/1200;

         AssertBalanceUnchanged(ca);       
    }

    [Fact]
    public void CreditInterest_ShouldNotCreditInterestToClosedAccount()
    {
        //arrange
        bank.CloseAccount(sa, password);

        //act
        var creditedAccounts= bank.CreditInterest();

        Assert.Equal(2, creditedAccounts);

        
    }


    [Fact()]
    public void CanCreateMultipleAccounts()
    {
        
        for(var i=0;i<1000;i++)
            bank.OpenAccount("Savings","Test Account", password, amount);
    }



}