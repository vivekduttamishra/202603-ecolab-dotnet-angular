using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public interface IAccountService
    {
        Task<BankAccount> GetAccount(int accountNumber);

        void Credit(BankAccount account, decimal amount);

        void Debit(BankAccount account, decimal amount);
    }
}
