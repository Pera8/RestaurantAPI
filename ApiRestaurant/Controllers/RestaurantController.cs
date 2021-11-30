using Microsoft.AspNetCore.Mvc;
using Service;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRestaurant.Controllers
{
    [Route("api/Restaurant")]
    public class RestaurantController : Controller
    {
        private readonly RestaurantService restaurantService;

        public RestaurantController(RestaurantService restaurantService)
        {
            this.restaurantService = restaurantService;
        }

        [HttpPost]
        public async Task<ActionResult> AddRestaurant(RestaurantDTO restaurantDTO)
        {
            return Ok(await restaurantService.AddAsync(restaurantDTO));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllRestaurant()
        {
            return Ok(await restaurantService.GetAllAsync());
        }

        [HttpGet("id")]
        public async Task<ActionResult> GetRestaurantById(int id)
        {
            return Ok(await restaurantService.GetAsyncById(id));
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteRestaurant(int id)
        {
            await restaurantService.DeleteAsync(id);
            return Ok();
        }
    }
}
