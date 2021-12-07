using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Repository
{
    public class OrderDetailsRepository: RepositoryBase<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateOrderDetails(OrderDetails orderDetails)
        {
            Create(orderDetails);
        }

        public void DeleteOrderDetails(OrderDetails orderDetails)
        {
            Delete(orderDetails);
        }

        public void UpdateOrderDetails(OrderDetails orderDetails)
        {
            Update(orderDetails);
        }
    }
}
