using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    public class CustomerDTOLight
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public WaiterDTO WaiterDto { get; set; }
        public int RestaurantId { get; set; }
    }
}
