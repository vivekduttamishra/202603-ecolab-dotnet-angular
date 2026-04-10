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
        IRepository<Customer, int> repository;
        public CustomerService(IRepository<Customer,int> repository)
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

        public async Task<Customer> GetCustomerByEmail(string email)
        {
            //return await repository.FindOne(c => c.Email == email);
            var all = await repository.GetAll();
            var customer= all.FirstOrDefault(c => c.Email == email);
            if (customer != null)
                return customer;
            else
                throw new InvalidIdException(email, $"Invalid Email : ${email}");
        }

        public async Task ActivateCustomer(int id, bool isActive=true)
        {
            Customer customer = await repository.GetById(id);
            customer.IsActive=isActive;
            await repository.Save();
        }

        public async Task<Customer> Login(string email, string password)
        {
            Customer customer = await repository.FindOne(c=>c.Email == email);
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

        public async Task<Customer> GetCustomerById(int id)
        {
            return await repository.GetById(id);
        }
    }
}
