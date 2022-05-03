using Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store
{
    public interface IOrdersRepository : IRepositoryBase<Orders>
    {
        IEnumerable<Orders> OrdersByCustomers(int customersNumber);
        Task CreateOrders(Orders orders);
        Task UpdateOrders(Orders orders);
        void DeleteOrders(Orders orders);
        Task<Orders> GetOrderByNumber(int orderNumber);
    }
}
