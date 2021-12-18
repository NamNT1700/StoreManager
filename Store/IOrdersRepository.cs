using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Store
{
    public interface IOrdersRepository: IRepositoryBase<Orders>
    {
        IEnumerable<Orders> OrdersByCustomers(int customersNumber);
        Task CreateOrders(Orders orders);
        Task UpdateOrders(Orders orders);
        void DeleteOrders(Orders orders);
        Task<Orders> GetOrderByNumber(int orderNumber);
    }
}
