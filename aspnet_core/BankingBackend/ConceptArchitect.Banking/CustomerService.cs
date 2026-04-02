using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public  class CustomerService
    {
        IRepository<Customer, string> repository;
        public CustomerService(IRepository<Customer,string> repository)
        {
            this.repository = repository;
        }

        public async Task<Customer> AddCustomer(Customer customer) 
        {
            //where are we gong to add the customer
            customer = await repository.Add(customer);
            await repository.Save();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await repository.GetAll();
        }

        public async Task ActivateCustomer(string email, bool isActive=true)
        {
            Customer customer = await repository.GetById(email);
            customer.IsActive=isActive;
            await repository.Save();
        }

        public async Task<Customer> Login(string email, string password)
        {
            Customer customer = await repository.GetById(email);
            if (customer.Password == password)
            {
                return customer;
            } else
            {
                throw new InvalidCredentialsException(email);
            }
        }

        public async Task ChangePassword(string email, string oldPassword, string newPassword)
        {
            Customer customer = await Login(email, oldPassword);
            customer.Password = newPassword;
        }
    }
}
