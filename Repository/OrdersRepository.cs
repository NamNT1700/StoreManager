using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using System.Linq;

namespace Repository
{
    public class OrdersRepository : RepositoryBase<Orders>, IOrdersRepository
    {
        public OrdersRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public IEnumerable<Orders> OrdersByCustomers(int customersNumber)
        {
            return FindByCondition(a => a.CustomersNumber.Equals(customersNumber)).ToList();
        }
    }
}
