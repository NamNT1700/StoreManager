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

        public void CreateProducts(Products products)
        {
            Create(products);
        }

        public void DeleteProducts(Products products)
        {
            Delete(products);
        }

        public void UpdateProducts(Products products)
        {
            Update(products);
        }
    }
}
