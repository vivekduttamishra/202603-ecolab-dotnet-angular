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
        string connectionString= "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\works\\corporate\\202603-ecolab-dotnet-angular\\aspnet_core\\BankingBackend\\ConceptArchitect.Banking.EFRepository\\EFBanking.mdf;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<BankAccount> Accounts { get; set; }

    }
}
