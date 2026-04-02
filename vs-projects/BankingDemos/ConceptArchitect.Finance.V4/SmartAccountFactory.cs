using ConceptArchitect.Finance.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    public delegate BankAccount AccountBuilder(int accountNumber, string name, string password, double amount);

    public class SmartAccountFactory : IAccountFactory
    {

        public SmartAccountFactory()
        {
            builders["SavingsAccount"] = (accountNumber, name, password, amount) => new SavingsAccount(accountNumber, name, password, amount);
            builders["CurrentAccount"] = (accountNumber, name, password, amount) => new CurrentAccount(accountNumber, name, password, amount);
            builders["OverdraftAccount"] = (accountNumber, name, password, amount) => new OverdraftAccount(accountNumber, name, password, amount);

        }

        Dictionary<string,AccountBuilder> builders = new Dictionary<string, AccountBuilder> ();
        public void AddAccountBuilder(string accountType, AccountBuilder builder)
        {
            builders[accountType]= builder;
        }

        public BankAccount Create(string accountType, int accountNumber, string name, string password, double amount)
        {
            if (builders.ContainsKey(accountType))
            {
                return builders[accountType](accountNumber,name, password, amount);
            }
            else
            {
                return DefaultAccountTypeHandler(accountType,accountNumber, name, password, amount);
            }
        }

        public BankAccount DefaultAccountTypeHandler(string accountType, int accountNumber, string name, string password, double amount)
        {
            throw new BankingException(0, $"Invalid Account Type: {accountType}");
        }
    }
}
