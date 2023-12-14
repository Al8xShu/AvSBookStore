using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AvSBookStore
{
    public interface IOrderRepository
    {
        //Order Create();

        Task<Order> CreateAsync();

        Order GetById(int id);

        Task<Order> GetByIdAsync(int id);

        void Update(Order order);

        Task UpdateAsync(Order order);
    }
}
