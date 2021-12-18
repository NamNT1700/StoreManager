using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Store
{
    public interface IOrderDetailsRepository: IRepositoryBase<OrderDetails>
    {
        Task CreateOrderDetails(OrderDetails orderDetails);
        Task UpdateOrderDetails(OrderDetails orderDetails);
        void DeleteOrderDetails(OrderDetails orderDetails);
        Task<OrderDetails> GetOrderByNumber(int orderNumber);
    }
}
