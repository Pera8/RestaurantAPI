using Mapster;
using Repository.Models;
using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public static class MapperConfig
    {
        public static void RegisterCustomerMapping()
        {
            TypeAdapterConfig<Customer, CustomerDTO>.NewConfig()
                .Map(x => x.RestaurantId,
                    src => src.Restaurant.Id,
                    src => src.Restaurant != null)
                .Map(x => x.WaiterId,
                    src => src.Waiter.Id,
                    src => src.Waiter != null);
            TypeAdapterConfig<CustomerDTO, Customer>.NewConfig();
        }

        public static void RegisterWaiterMapping()
        {
            TypeAdapterConfig<Waiter, WaiterDTO>.NewConfig()
                .Map(x => x.RestaurantId,
                    src => src.Restaurant.Id,
                    src => src.Restaurant != null);               
            TypeAdapterConfig<WaiterDTO, Waiter>.NewConfig();
        }

        public static void RegisterRestaurantMapping()
        {
            TypeAdapterConfig<Restaurant, RestaurantDTO>.NewConfig();              
            TypeAdapterConfig<RestaurantDTO, Restaurant>.NewConfig();
        }

        public static void RegisterCustomerToWaiterMapping2()
        {
            TypeAdapterConfig<CustomerDTOLight, Customer>.NewConfig()
                .Map(x => x.Waiter,
                    src => src.WaiterDto,
                    src => src.WaiterDto != null);
            TypeAdapterConfig<Customer, CustomerDTOLight>.NewConfig();
        }

        public static void RegisterCustomerToWaiterMapping()
        {
            TypeAdapterConfig<Customer, CustomerDTOLight>.NewConfig()
                .Map(x => x.WaiterDto,
                    src => src.Waiter,
                    src => src.Waiter != null);
            TypeAdapterConfig<CustomerDTOLight , Customer>.NewConfig();
        }
    }
}
