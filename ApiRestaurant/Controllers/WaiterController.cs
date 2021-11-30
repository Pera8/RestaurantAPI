using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurant.Controllers
{
    [Route("api/Waiter")]
    public class WaiterController : Controller
    {
        private readonly WaiterService waiterService;

        public WaiterController(WaiterService waiterService)
        {
            this.waiterService = waiterService;
        }

        [HttpPost]
        public async Task<ActionResult> AddWaiter(WaiterDTO waiterDTO)
        {
            return Ok(await waiterService.AddAsync(waiterDTO));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllWaiter()
        {
            return Ok(await waiterService.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetWaiterById(int id)
        {
            return Ok(await waiterService.GetAsyncById(id));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteWaiter (int id)
        {
            await waiterService.DeleteAsync(id);
            return Ok();
        }
    }
}
