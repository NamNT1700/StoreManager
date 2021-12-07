using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Store
{
    public interface IPaymentsRepository: IRepositoryBase<Payments>
    {
        void CreatePayments(Payments payments);
        void UpdatePayments(Payments payments);
        void DeletePayments(Payments payments);
    }
}
