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
using System.Net.Http.Headers;
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

            //CustomerManagement(context);

            var accountType = Input.GetString("Account Type", null);
            if(accountType!=null)
            {
               
                var balance = Input.Get<double>("Balance?");
                BankAccount account = null;
                var customer = context.Customers.FirstOrDefault();
                if (accountType=="SavingsAccount")
                {
                    account = new SavingsAccount()
                    {
                        Balance = balance,
                        MinBalance = 10000
                    };
                } else if (accountType=="OverdraftAccount")
                {
                    account = new OverdraftAccount()
                    { 
                        Balance=balance,
                        OdLimit= balance/10
                       
                    };

                }else if (accountType=="CurrentAccount")
                {
                    account = new CurrentAccount()
                    { 
                        Balance=balance
                    };

                }
                else
                {
                    return;
                }


                account.Owner = customer;
                context.Accounts.Add(account);
                context.SaveChanges();
                Console.WriteLine("New Account Number is :" + account.AccountNumber);
            }

            Console.WriteLine("\n\nShowing All Accounts\n\n");
            foreach(var account in context.Accounts)
            {
                Console.Write($"{account.GetType().Name} {account.AccountNumber} {account.Balance}   ");
                if (account is SavingsAccount sa)
                    Console.WriteLine($"Min Balance={sa.MinBalance}");
                else if (account is OverdraftAccount oda)
                    Console.WriteLine($"OdLimit ={oda.OdLimit}");
                else
                    Console.WriteLine();
            }

        }

        private static void CustomerManagement(BankingContext? context)
        {
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
