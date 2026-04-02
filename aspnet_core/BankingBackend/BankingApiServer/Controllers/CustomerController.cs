using ConceptArchitect.Banking;
using Microsoft.AspNetCore.Mvc;

namespace BankingApiServer.Controllers
{

    [ApiController]
    [Route("/api/customers")]
    public class CustomerController: ControllerBase
    {
        CustomerService service;
        public CustomerController(CustomerService service)
        {
            this.service = service;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await service.GetAllCustomers();
        }

    }
}
