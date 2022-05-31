using Base.Contract;
using Base.Data;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.Repository
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IdentityServerDbContext context) : base(context)
        {
        }
    }
}