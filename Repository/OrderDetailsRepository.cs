using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderDetailsRepository : RepositoryBase<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateOrderDetails(OrderDetails orderDetails)
        {
            await Task.Run(() => Create(orderDetails));
        }

        public void DeleteOrderDetails(OrderDetails orderDetails)
        {
            Delete(orderDetails);
        }

        public async Task<OrderDetails> GetOrderByNumber(int orderNumber)
        {
            return await FindByCondition(order => order.OrderNumberFK.Equals(orderNumber))
            .FirstOrDefaultAsync();
        }

        public async Task UpdateOrderDetails(OrderDetails orderDetails)
        {
            await Task.Run(() => Update(orderDetails));
        }
    }
}
