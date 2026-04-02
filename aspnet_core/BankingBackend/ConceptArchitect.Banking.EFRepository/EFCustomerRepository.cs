using ConceptArchitect.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking.EFRepository
{
    public class EFCustomerRepository : IRepository<Customer, String>
    {
        public Task<Customer> Add(Customer customer)
        {
            throw new NotImplementedException();
        }

       

        public Task<IEnumerable<Customer>> FindAll(Func<Customer, bool> matcher)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> FindOne(Func<Customer, bool> matcher)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Customer>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetById(string Id)
        {
            throw new NotImplementedException();
        }

        public Task Save()
        {
            throw new NotImplementedException();
        }

      

        public Task<Customer> Update(Customer customer, Action<Customer, Customer> mergeOldNew)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteById(string Id)
        {
            
        }
    }
}
