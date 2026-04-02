using ConceptArchitect.Finance.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    public class StupidAccountFactory : IAccountFactory
    {
        public BankAccount Create(string accountType, int accountNumber, string name, string password, double amount)
        {
            BankAccount account = null;
            switch (accountType)
            {
                case "SavingsAccount":
                    account = new SavingsAccount(accountNumber, name, password, amount);
                    break;
                case "CurrentAccount":
                    account = new CurrentAccount(accountNumber, name, password, amount);
                    break;
                case "OverdraftAccount":
                    account = new OverdraftAccount(accountNumber, name, password, amount);
                    break;
                default:
                    account=DefaultAccountTypeHandler(accountType,accountNumber,name,password,amount);
                    break;
            }
            return account;
        }

        public BankAccount DefaultAccountTypeHandler(string accountType, int accountNumber, string name, string password, double amount)
        {
            return new SavingsAccount(accountNumber, name, password, amount);   
        }
    }
}
