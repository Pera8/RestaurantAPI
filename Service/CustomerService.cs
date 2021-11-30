using Mapster;
using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Repository.IRepository;
using Service.Mapper;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Service
{
    public class CustomerService : IRepository<Customer>
    {
        static CustomerService()
        {
            MapperConfig.RegisterCustomerMapping();
            MapperConfig.RegisterCustomerToWaiterMapping();
        }

        private IRepository<Customer> repositoryCustomer;
        private IRepository<Waiter> repositoryWaiter;
        private IRepository<Restaurant> repositoryRestaurant;

        public CustomerService(IRepository<Customer> repositoryCustomer, IRepository<Waiter> repositoryWaiter, IRepository<Restaurant> repositoryRestaurant)
        {
            this.repositoryCustomer = repositoryCustomer;
            this.repositoryRestaurant = repositoryRestaurant;
            this.repositoryWaiter = repositoryWaiter;
        }
        public async Task<Customer> AddAsync(CustomerDTO model)
        {
            if (model == null)
            {
                throw new Exception("Customer can not be null");
            }
            var modelCustomer = TypeAdapter.Adapt<CustomerDTO, Customer>(model);

            modelCustomer.Waiter = await repositoryWaiter.GetAsyncById(model.WaiterId);
            modelCustomer.Restaurant = await repositoryRestaurant.GetAsyncById(model.RestaurantId);                      
            return await AddAsync(modelCustomer);
        }
       

        public async Task DeleteAsync(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }
            await repositoryCustomer.DeleteAsync(id);
        }

        public async Task<DbSet<Customer>> GetAllAsync()
        {            
            return await repositoryCustomer.GetAllAsync();
        }

        public async Task<Customer> GetAsyncById(int id)
        {
            if (id < 1)
            {
                throw new Exception("id can not be null");
            }

            return await repositoryCustomer.GetAsyncById(id);
        }

        public async Task<Customer> AddAsync(Customer model)
        {
            return await repositoryCustomer.AddAsync(model);
        }

        public async Task<CustomerDTOLight> GetCustomerWithWaiterDTO(int id)
        {
            var customer = await repositoryCustomer.GetWithRelationAsyncById(id);
            var a = await customer.Include(x => x.Waiter).FirstOrDefaultAsync();
            var modelCustomer =  TypeAdapter.Adapt<Customer, CustomerDTOLight>(a);
            return modelCustomer;
           
        }

        public Task<IQueryable<Customer>> GetWithRelationAsyncById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
