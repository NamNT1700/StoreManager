using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Store
{
    public interface IOrdersRepository: IRepositoryBase<Orders>
    {
        IEnumerable<Orders> OrdersByCustomers(int customersNumber);
        void CreateOrders(Orders orders);
        void UpdateOrders(Orders orders);
        void DeleteOrders(Orders orders);
    }
}
