using ConceptArchitect.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking.EFRepository
{
    public class EFCustomerRepository : IRepository<Customer, String>
    {
        BankingContext context;
        public EFCustomerRepository(BankingContext context)
        {
            this.context = context;
        }


        public async Task<Customer> Add(Customer customer)
        {
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
            return customer;
        }

       

        public async Task<IEnumerable<Customer>> FindAll(Func<Customer, bool> matcher)
        {
            var customers = await (from customer in context.Customers
                             where matcher(customer)
                             select customer).ToListAsync();

            return customers;
        }

        public async Task<Customer> FindOne(Func<Customer, bool> matcher)
        {
            return await context.Customers.FirstOrDefaultAsync(c => matcher(c));
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer> GetById(string id)
        {
            var customer= await context.Customers.FirstOrDefaultAsync(c => c.Email == id);
            if (customer == null)
                throw new InvalidIdException<string>(id);

            return customer;
        }

        public async Task Save()
        {
            await context.SaveChangesAsync();
        }

      

        public async Task<Customer> Update(Customer customer, Action<Customer, Customer> mergeOldNew)
        {
            var oldCustomer = await GetById(customer.Email);
            mergeOldNew(oldCustomer, customer);
            await context.SaveChangesAsync();
            return oldCustomer;
        }

        public async Task DeleteById(string id)
        {
            var customer = await GetById(id);
            context.Customers.Remove(customer);
            await context.SaveChangesAsync();
        }
    }
}
