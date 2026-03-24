namespace ConceptArchitect.Finance;

using ConceptArchitect.Finance;

public class CurrentAccountSpec
{
    CurrentAccount account;
    string name="Current Account";
    string password="p@ss";
    double amount=20000;
    int accountNumber=1;

    public CurrentAccountSpec()
    {
        account = new CurrentAccount(accountNumber,name,password,amount);
    }

    [Fact]
    public void CurrentAccountShouldBeABankAccount()
    {
        Assert.IsType(typeof(CurrentAccount), account);
        Assert.True(account is BankAccount);
    }

    [Fact(
       // Skip ="Not yet implemented"
    )]
    public void CurrentAccountShouldCreditNoInterest()
    {
        // //Act
        account.CreditInterest(12);

        //Assert
        Assert.Equal(amount, account.Balance,0.01); //balance remains unchanged
    }


}