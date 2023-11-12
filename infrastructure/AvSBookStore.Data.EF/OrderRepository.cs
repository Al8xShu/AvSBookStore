using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvSBookStore.Data.EF
{
    public class OrderRepository : IOrderRepository
    {
        public Task<Order> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
