using System;
using System.Collections.Generic;
using System.Text;

namespace AvSBookStore
{
    public interface IOrderRepository
    {
        Order Create();

        Order GteById(int id);

        void Update(Order order);
    }
}
