using ConceptArchitect.Finance.Exceptions;
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
        this.bank = bank;
    }

    public void Start()
    {

        LoginScreen();
        PrintInfo("ATM shutdown");

    }

    private void LoginScreen()
    {
        while (true)
        {
            try
            {

                Console.Clear();
                Console.WriteLine("Login Menu");
                accountNumber = keyboard.GetInt("Account Number: ");
                password = keyboard.GetString("Password: ");
                if (accountNumber == -1 && password == "NIMDA")
                    AdminMenu();
                else
                    MainMenu();
            }
            catch (BankingException ex)
            {
                PrintError(ex.Message);
                keyboard.GetString("Hit Enter to exit");
            }
        }
    }

    private void AdminMenu()
    {
        int choice;
        do
        {
            choice = keyboard.GetInt("1. Open Account 2. Credit Interest 3. Show All Accounts 4. Shutdown 0. Exit");
            //DO IT YOURSELF

        } while (choice != 0);
    }

    private void MainMenu()
    {
        int choice=0;
        do
        {
            //Console.Clear();
            
            try
            {

                choice = keyboard.GetInt("1. Deposit 2. Withdraw 3. Transfer 4. Show Balance 5. Close Account 0. Exit");
                switch (choice)
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
            }
            catch(InvalidDenominationException ex)
            {
                PrintError(ex.Message);
            }
            catch(InsufficientBalanceException ex)
            {
                PrintError($"Insufficient Balance. Total Deficit is {ex.Deficit}");
            }
            catch(InvalidAccountException ex)
            {
                //from account shouldn't be invalid
                if(ex.AccountNumber!=accountNumber)
                {
                    PrintError($"Invalid Recepient Account: {ex.AccountNumber}");
                }
                else
                    throw;
            }



        } while (choice != 0);
    }

    private void HandleCloseAccount()
    {
        var confirmPassword = keyboard.GetString("Re confirm password to close your account:");

        var balance = bank.CloseAccount(accountNumber, confirmPassword);
        PrintInfo("Your Account is Closed");
        DispenseCash((int)balance);
    }

    private void HandleShowInfo()
    {
        var info = bank.GetInfo(accountNumber, password);
        PrintInfo(info);
    }

    private void HandleTransfer()
    {
        var toAccount = keyboard.GetInt("To Account?");
        var amount = keyboard.GetInt("Amount?");

        bank.Transfer(accountNumber, amount, password, toAccount);
        PrintInfo("Transfer successful");
    }

    private void HandleWithdraw()
    {
        var amount = keyboard.GetInt("Amount? ");
        bank.Withdraw(accountNumber, amount, password);
        DispenseCash(amount);
        PrintInfo("Transaction Success");
    }

    private void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }

    private void PrintInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        System.Console.WriteLine(message);
        Console.ResetColor();
    }

    private void DispenseCash(int amount)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Please collect your cash: ₹{amount}");
        Console.ResetColor();
    }

    private void HandleDeposit()
    {
        var amount = keyboard.GetInt("Amount?");
        bank.Deposit(accountNumber, amount);
        PrintInfo("Amount Deposited");
    }
}