using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Store
{
    public interface IOrderDetailsRepository: IRepositoryBase<OrderDetails>
    {
        void CreateOrderDetails(OrderDetails orderDetails);
        void UpdateOrderDetails(OrderDetails orderDetails);
        void DeleteOrderDetails(OrderDetails orderDetails);
    }
}
