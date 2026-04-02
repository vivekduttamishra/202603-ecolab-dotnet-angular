using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking.EFRepository
{
    public class BankingContext : DbContext
    {
        public BankingContext(DbContextOptions<BankingContext> options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> Accounts { get; set; }

    }
}
