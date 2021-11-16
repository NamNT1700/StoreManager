using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Repository
{
    public class OrderDetailsRepository: RepositoryBase<OrderDetails>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
