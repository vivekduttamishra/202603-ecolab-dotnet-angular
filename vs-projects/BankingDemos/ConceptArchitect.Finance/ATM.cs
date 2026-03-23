using ConceptArchitect.Utils;

namespace ConceptArchitect.Finance.Firmeware;

public class ATM
{
    Input keyboard = new Input();
    Bank bank;
    int accountNumber;
    string password;

    public ATM(Bank bank)
    {
        this.bank=bank;
    }

    public void Start()
    {
        
            LoginScreen();
      
    }

    private void LoginScreen()
    {
        while(true)
        {
            accountNumber = keyboard.GetInt("Account NUmber");
            password = keyboard.GetString("pin");
            if(accountNumber==-1 && password=="NIMDA")
                AdminMenu();
            else
                MainMenu();
        }
    }

    private void AdminMenu()
    {
        int choice;
        do
        {
            choice = keyboard.GetInt("1. Open Account 2. Credit Interest 3. Show All Accounts 4. Shutdown 0. Exit");
            //DO IT YOURSELF
            
        }while(choice!=0);
    }

    private void MainMenu()
    {
        int choice;
        do
        {
            choice = keyboard.GetInt("1. Deposit 2. Withdraw 3. Transfer 4. Show Balance 5. Close Account 0. Exit");
            switch(choice)
            {
                case 1:
                    HandleDeposit();
                    break;
                case 2:
                    HandleWithdraw();
                    break;
                case 3:
                    HandleTransfer();
                    break;
                case 4:
                    HandleShowInfo();
                    break;
                case 5:
                    HandleCloseAccount();
                    return;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }


        }while(choice!=0);
    }

    private void HandleCloseAccount()
    {
        var confirmPassword=keyboard.GetString("Re confirm password to close your account:");

        var balance=bank.CloseAccount(accountNumber, confirmPassword);
        if(double.IsNaN(balance))
            PrintError("Account Close Failed");
        else
        {
            PrintInfo("Your Account is Closed");
            DispenseCash((int)balance);
        }
    }

    private void HandleShowInfo()
    {
        var info = bank.GetInfo(accountNumber,password);
        PrintInfo(info);
    }

    private void HandleTransfer()
    {
        throw new NotImplementedException();
    }

    private void HandleWithdraw()
    {
        var amount = keyboard.GetInt("Amount? ");
        bool success = bank.Withdraw(accountNumber, amount, password);
        if (success)
        {
            DispenseCash(amount);
            PrintInfo("Transaction Success");

        }
        else
        {
            PrintError("Transction Failed");
        }

    }

    private void PrintError(string message)
    {
         Console.ForegroundColor=ConsoleColor.Red;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }

    private void PrintInfo(string message)
    {
        Console.ForegroundColor=ConsoleColor.Blue;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }

    private void DispenseCash(int amount)
    {
        Console.ForegroundColor=ConsoleColor.Yellow;
        Console.WriteLine($"Please collect your cash: ₹{amount}");
        Console.ResetColor();
    }

    private void HandleDeposit()
    {
        throw new NotImplementedException();
    }
}