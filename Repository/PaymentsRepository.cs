using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System.Threading.Tasks;

namespace Repository
{
    public class PaymentsRepository : RepositoryBase<Payments>, IPaymentsRepository
    {
        public PaymentsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreatePayments(Payments payments)
        {
            await Task.Run(() => Create(payments));
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
