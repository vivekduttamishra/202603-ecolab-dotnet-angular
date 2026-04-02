using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class Customer 
    {
        public string Name { get; set; }
        
        [Key]
        public string Email { get; set; }  //email

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public string Password { get; set; }
       
        public string? Photo { get; set; }

        public string? Phone { get; set; }

        public virtual IList<BankAccount> Accounts { get; set; }
        
    }
}
