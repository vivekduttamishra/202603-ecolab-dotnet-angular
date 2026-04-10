using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class DataSeeder
    {
        CustomerService customerService;
        public DataSeeder(CustomerService customerService)
        {
            this.customerService = customerService;
        }


        public async Task<IEnumerable<Customer>> CreateCustomers()
        {
            await customerService.AddCustomer(new Customer()
            {
                Name ="Seema Singh",
                Email="seema@gmail.com",
                Password="p@ssword#1",
                Phone="99990 99990",
                Photo= "https://randomuser.me/api/portraits/women/76.jpg",
                Address="Hosa Road, Bangalore"
            });

            await customerService.AddCustomer(new Customer()
            {
                Name = "Sanjay Mall",
                Email = "sanjay@gmail.com",
                Phone = "99990 99991",
                Password = "p@ssword#1",
                Photo = "https://randomuser.me/api/portraits/men/79.jpg",
                Address = "ECity, Hyderabad"
            });

            await customerService.AddCustomer(new Customer()
            {
                Name = "Ananya Shekh",
                Email = "ananya@gmail.com",
                Phone = "99990 99992",
                Password = "p@ssword#1",
                Photo = "https://randomuser.me/api/portraits/women/49.jpg",
                Address = "Kothrud, Pune"
            });

            return await customerService.GetAllCustomers();
        }
    }
}
