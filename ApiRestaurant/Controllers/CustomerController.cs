using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurant.Controllers
{
    [Route("api/Customer")]
    public class CustomerController : Controller
    {
        private readonly CustomerService customerService;

        public CustomerController(CustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpPost]
        public async Task<ActionResult> AddCustomer(CustomerDTO customerDTO)
        {
            return Ok(await customerService.AddAsync(customerDTO));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllCustomer()
        {
            return Ok(await customerService.GetAllAsync());
        }

        //[HttpGet("id")]
        //public async Task<ActionResult> GetCustomerById (int id)
        //{
        //    return Ok(await customerService.GetAsyncById(id));
        //}

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            await customerService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetCustomerWithDTO(int id)
        {
            return Ok(await customerService.GetCustomerWithWaiterDTO(id));
        }
    }
}
