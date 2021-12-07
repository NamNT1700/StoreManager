using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Repository
{
    public class PaymentsRepository: RepositoryBase<Payments>, IPaymentsRepository
    {
        public PaymentsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreatePayments(Payments payments)
        {
            Create(payments);
        }

        public void DeletePayments(Payments payments)
        {
            Delete(payments);
        }

        public void UpdatePayments(Payments payments)
        {
            Update(payments);
        }
    }
}
