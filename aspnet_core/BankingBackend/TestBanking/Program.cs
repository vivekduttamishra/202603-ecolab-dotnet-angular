using ConceptArchitect.Banking;
using ConceptArchitect.Banking.EFRepository;
using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanking
{
    class Program
    {
        static void Main()
        {
            var services = ConfigureServices();


            //var optionsBuilder = new DbContextOptionsBuilder<BankingContext>();
            //optionsBuilder.UseSqlServer(connectionString);
            //var options = optionsBuilder.Options;


            //var context = new BankingContext(options);

            var context = services.GetService<BankingContext>();


            string name = Input.GetString("Name?", null);
            if (name != null)
            {

                var newCustomer = new Customer()
                {
                    Name = name,
                    Password = Input.GetString("Password"),
                    Email = Input.GetString("Email?"),
                    Address = Input.GetString("Address?"),
                    IsActive = true

                };

                context.Customers.Add(newCustomer);
                context.SaveChanges();

            }

            Console.WriteLine("\n\nList of all Customers");
            Console.WriteLine("\n-------------------\n");

            //list of all customers
            foreach (var customer in context.Customers)
            {
                Console.WriteLine($"{customer.Name}\t{customer.Email}");
            }

        }

        private static ServiceProvider ConfigureServices()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("BankingContext");
            var service = new ServiceCollection();
            service.AddDbContext<BankingContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            return service.BuildServiceProvider();
        }
    }
}
