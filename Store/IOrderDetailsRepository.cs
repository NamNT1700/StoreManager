using Entities.Models;
using System.Threading.Tasks;

namespace Store
{
    public interface IOrderDetailsRepository : IRepositoryBase<OrderDetails>
    {
        Task CreateOrderDetails(OrderDetails orderDetails);
        Task UpdateOrderDetails(OrderDetails orderDetails);
        void DeleteOrderDetails(OrderDetails orderDetails);
        Task<OrderDetails> GetOrderByNumber(int orderNumber);
    }
}
