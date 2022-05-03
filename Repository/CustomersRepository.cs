using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class CustomersRepository : RepositoryBase<Customers>, ICustomersRepository
    {


        public CustomersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
        public async Task CreateCustomers(Customers customers)
        {
            await Task.Run(() => Create(customers));
        }
        public async Task UpdateCustomers(Customers customers)
        {
            await Task.Run(() => Update(customers));
        }

        public void DeleteCustomers(Customers customers)
        {
            Delete(customers);
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return FindAll()
                .OrderBy(ow => ow.CustomersName)
                .ToList();
        }

        public async Task<Customers> GetCumstomersByID(int CustumersID)
        {
            return await FindByCondition(customers => customers.CustomersId.Equals(CustumersID))
            .FirstOrDefaultAsync();
        }

        public Customers GetCumstomersByPostalCode(Guid PostalCode)
        {
            return FindByCondition(customers => customers.PostalCode.Equals(PostalCode))
           .FirstOrDefault();
        }

        public Customers GetCustomersWithDetails(int CustumersID)
        {
            return FindByCondition(customers => customers.CustomersId.Equals(CustumersID))
        .Include(orders => orders.Orders)
        .FirstOrDefault();
        }


    }
}
