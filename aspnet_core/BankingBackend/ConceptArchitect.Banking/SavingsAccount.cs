using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class SavingsAccount : BankAccount
    {
        public double MinBalance { get; set; } = 5000;

        public override double EffectiveBalance => Balance - MinBalance;
    }
}
