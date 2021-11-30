using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Service.Mapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class RestaurantService : IRepository<Restaurant>
    {
        static RestaurantService() => MapperConfig.RegisterRestaurantMapping();

        private readonly IRepository<Restaurant> repositoryRestaurant;
        public RestaurantService(IRepository<Restaurant> repositoryRestaurant)
        {
            this.repositoryRestaurant = repositoryRestaurant;
        }
        public async Task<Restaurant> AddAsync(RestaurantDTO model)
        {
            if (model == null)
            {
                throw new Exception("Restaurant can not be null");
            }
            var modelRestaurant = TypeAdapter.Adapt<RestaurantDTO, Restaurant>(model);
            
            return await repositoryRestaurant.AddAsync(modelRestaurant);
        }

        public async Task<Restaurant> AddAsync(Restaurant model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
             await repositoryRestaurant.DeleteAsync(id); 
        }

        public async Task<DbSet<Restaurant>> GetAllAsync()
        {
            return await repositoryRestaurant.GetAllAsync();
        }

        public async Task<Restaurant> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryRestaurant.GetAsyncById(id);
        }

        public Task<IQueryable<Restaurant>> GetWithRelationAsyncById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
