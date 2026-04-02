using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    
    public interface IAccountFactory
    {
        
        public BankAccount DefaultAccountTypeHandler(string accountType, int accountNumber, string name, string password, double amount);
        BankAccount Create(string accountType,int accountNumber, string name, string password, double amount);   
        
    }
}
