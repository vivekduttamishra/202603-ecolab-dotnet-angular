using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class Customer : Entity<string>
    {
        public string Name { get; set; }
        public string Id { get; set; }  //email

        public string Address { get; set; }

        public bool IsActive { get; set; }

        public string Password { get; set; }
        public string ProfilePhoto { get; set; }
        public string Phone { get; set; }

        
    }
}
