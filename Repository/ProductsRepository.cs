using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Repository
{
    public class ProductsRepository: RepositoryBase<Products>, IProductsRepository
    {
        public ProductsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
