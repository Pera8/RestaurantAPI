using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
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
    public class WaiterService : IRepository<Waiter>
    {
        static WaiterService() => MapperConfig.RegisterWaiterMapping();

        private readonly IRepository<Waiter> repositoryWaiter;
        private readonly IRepository<Restaurant> repositoryRestaurant;
        public WaiterService(IRepository<Waiter> repositoryWaiter, IRepository<Restaurant> repositoryRestaurant)
        {
            this.repositoryWaiter = repositoryWaiter;
            this.repositoryRestaurant = repositoryRestaurant;
        }
        public async Task<Waiter> AddAsync(WaiterDTO model)
        {
            if (model == null)
            {
                throw new Exception("Customer can not be null");
            }
            var modelWaiter = TypeAdapter.Adapt<WaiterDTO, Waiter>(model);

            modelWaiter.Restaurant = await repositoryRestaurant.GetAsyncById(model.RestaurantId);
           
            return await repositoryWaiter.AddAsync(modelWaiter);
        }

        public Task<Waiter> AddAsync(Waiter model)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
             await repositoryWaiter.DeleteAsync(id);
        }

        public async Task<DbSet<Waiter>> GetAllAsync()
        {
            return await repositoryWaiter.GetAllAsync();
        }

        public async Task<Waiter> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            return await repositoryWaiter.GetAsyncById(id); 
        }

        public Task<IQueryable<Waiter>> GetWithRelationAsyncById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
