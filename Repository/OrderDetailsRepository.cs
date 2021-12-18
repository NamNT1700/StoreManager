using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OrderDetailsRepository: RepositoryBase<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateOrderDetails(OrderDetails orderDetails)
        {
           await Task.Run(()=> Create(orderDetails));
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
