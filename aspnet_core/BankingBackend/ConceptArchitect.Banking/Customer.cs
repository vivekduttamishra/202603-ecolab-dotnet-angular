using ConceptArchitect.Utils;
using ConceptArchitect.Utils.Validators;
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
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        [EmailAddress] //must be a valid email address
        public string Email { get; set; }  //email

        [StringLength(200, MinimumLength = 20)]
        public string Address { get; set; }

        public bool IsActive { get; set; }

        [StringLength(15, MinimumLength=5)]
        public string Password { get; set; }
       
        public string? Photo { get; set; }

        [OnlyDigits(AllowSeparators =true)]
        public string? Phone { get; set; }

        public virtual IList<BankAccount> Accounts { get; set; } =new List<BankAccount>();
        
    }
}
