using Entities.Models;
using System.Threading.Tasks;

namespace Store
{
    public interface IPaymentsRepository : IRepositoryBase<Payments>
    {
        Task CreatePayments(Payments payments);
        Task UpdatePayments(Payments payments);
        void DeletePayments(Payments payments);
        Task<Payments> GetPaymentByNumber(int customerID);
    }
}
