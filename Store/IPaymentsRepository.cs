using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Store
{
    public interface IPaymentsRepository: IRepositoryBase<Payments>
    {
        Task CreatePayments(Payments payments);
        Task UpdatePayments(Payments payments);
        void DeletePayments(Payments payments);
        Task<Payments> GetPaymentByNumber(int customerID);
    }
}
