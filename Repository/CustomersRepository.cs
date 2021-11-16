using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Store;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class CustomersRepository: RepositoryBase<Customers>, ICustomersRepository
    {
        public CustomersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateCustomers(Customers customers)
        {
            Create(customers);
        }

        public void DeleteCustomers(Customers customers)
        {
            Delete(customers);
        }

        public IEnumerable<Customers> GetAllCustomers()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }

        public Customers GetCumstomersByNumber(int CustumersNumber)
        {
            return FindByCondition(customers => customers.CustomersNumber.Equals(CustumersNumber))
            .FirstOrDefault();
        }

        public Customers GetCumstomersByPostalCode(Guid PostalCode)
        {
            return FindByCondition(customers => customers.PostalCode.Equals(PostalCode))
           .FirstOrDefault();
        }

        public Customers GetCustomersWithDetails(int CustumersNumber)
        {
            return FindByCondition(customers => customers.CustomersNumber.Equals(CustumersNumber))
        .Include(orders => orders.Orders)
        .FirstOrDefault();
        }

        public void UpdateCustomers(Customers customers)
        {
            Update(customers);
        }
    }
}
