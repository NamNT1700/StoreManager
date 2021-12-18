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
    public class PaymentsRepository: RepositoryBase<Payments>, IPaymentsRepository
    {
        public PaymentsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreatePayments(Payments payments)
        {
          await Task.Run(()=>  Create(payments));
        }

        public void DeletePayments(Payments payments)
        {
            Delete(payments);
        }

        public async Task<Payments> GetPaymentByNumber(int customerID)
        {
            return await FindByCondition(x => x.CustomersIdFK.Equals(customerID)).FirstOrDefaultAsync();
        }

        public async Task UpdatePayments(Payments payments)
        {
            await Task.Run(() => Update(payments));
        }
    }
}
