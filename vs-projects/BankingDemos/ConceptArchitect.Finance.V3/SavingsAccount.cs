using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Finance
{
    public class SavingsAccount : BankAccount
    {
        public int MinBalance { get; set; }
        public SavingsAccount(int accountNumber, string name, string password, double amount)
            : base(accountNumber, name, password, amount)
        {
            MinBalance = 5000;
        }

        public override bool Withdraw(double amount, string password)
        {
            if (amount > Balance - MinBalance)
                return false;

            return base.Withdraw(amount,password);
        }
    }
}
