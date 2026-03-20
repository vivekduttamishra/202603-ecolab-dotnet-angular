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
            choice = keyboard.GetInt("1. Deposit 2. Withdraw 3. Transfer 5. Show Balance 5. Close Account 0. Exit");
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
                    ShowInfo();
                    break;
                case 5:
                    CloseAccount();
                    return;
                case 0:
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }


        }while(choice!=0);
    }

    private void CloseAccount()
    {
        throw new NotImplementedException();
    }

    private void ShowInfo()
    {
        throw new NotImplementedException();
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
        Console.Error.WriteLine(message);
    }

    private void PrintInfo(string message)
    {
        Console.WriteLine(message);
    }

    private void DispenseCash(int amount)
    {
        Console.WriteLine($"Please collect your cash: ₹{amount}");
    }

    private void HandleDeposit()
    {
        throw new NotImplementedException();
    }
}