using ConceptArchitect.Banking;
using ConceptArchitect.Utils;
using ConceptArchitect.Utils.Web;
using Microsoft.AspNetCore.Mvc;

namespace BankingApiServer.Controllers
{

    [ApiController]
    [Route("/api/customers")]  //this is base_url
    [ExceptionMapper(typeof(DuplicateEntityException), 400)]
    //[InvalidIdMapper]
    public class CustomerController: ControllerBase
    {
        CustomerService service;
        public CustomerController(CustomerService service)
        {
            this.service = service;
        }


        [HttpGet] //base_url
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await service.GetAllCustomers();
        }

        [HttpGet("{email}")] //base_url + "/email"
        
        public async Task<Customer> GetCustomerById(string email)
        {

                var customer = await service.GetCustomerByEmail(email);
                return customer; 
        }

        [HttpPost]
        public async Task<Customer> AddNewCustomer()
        {
            throw new DuplicateEntityException("Duplicate Customer Email");
        }
    }
}