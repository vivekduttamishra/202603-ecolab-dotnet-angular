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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                    .Entity<BankAccount>()
                    .HasDiscriminator<string>("AccountType") //create a string column AccountType
                    .HasValue<SavingsAccount>("SavingsAccount")
                    .HasValue<CurrentAccount>("CurrentAccount")
                    .HasValue<OverdraftAccount>("OverdraftAccount");

            
                



        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> Accounts { get; set; }

    }
}
