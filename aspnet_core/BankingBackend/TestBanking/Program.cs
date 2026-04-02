using ConceptArchitect.Banking;
using ConceptArchitect.Banking.EFRepository;
using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBanking
{
    class Program
    {
        static void Main()
        {
            var context = new BankingContext();

            string name = Input.GetString("Name?", null);
            if (name != null)
            {

                var newCustomer = new Customer()
                {
                    Name = name,
                    Password = Input.GetString("Password"),
                    Email = Input.GetString("Email?"),
                    Address = Input.GetString("Address?"),
                    IsActive=true

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
    }
}
