using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class OverdraftAccount : BankAccount
    {
        public double OdLimit { get; set; }
    }
}
