using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class OrdersRepository : RepositoryBase<Orders>, IOrdersRepository
    {
        public OrdersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateOrders(Orders orders)
        {
            await Task.Run(() => Create(orders));
        }

        public void DeleteOrders(Orders orders)
        {
            Delete(orders);
        }

        public async Task<Orders> GetOrderByNumber(int orderNumber)
        {
            return await FindByCondition(x => x.OrderNumber.Equals(orderNumber))
           .FirstOrDefaultAsync();
        }

        public IEnumerable<Orders> OrdersByCustomers(int customersNumber)
        {
            return FindByCondition(a => a.CustomersFK.Equals(customersNumber)).ToList();
        }

        public async Task UpdateOrders(Orders orders)
        {
            await Task.Run(() => Update(orders));
        }
    }
}
