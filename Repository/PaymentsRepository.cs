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
    }
}
