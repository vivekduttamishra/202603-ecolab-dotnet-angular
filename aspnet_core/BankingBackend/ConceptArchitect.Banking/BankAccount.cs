using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{

    public enum AccountStatus
    {
        Active,
        Inactive,
        Closed
    }
    public  class BankAccount
    {
        [Key]
        public int AccountNumber { get; set; }
        public double Balance { get; set; }

        //reference to Customer
        public virtual Customer Owner { get; set; }

        public AccountStatus Status { get; set; }

        public virtual void Debit(double amount)
        {
            Balance -= amount;
        }
        public virtual void Credit(double amount)
        {
            Balance += amount;
        }

        public virtual double EffectiveBalance
        {
            get {  return Balance; }
        }
    }
}
