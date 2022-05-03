using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductsRepository : RepositoryBase<Products>, IProductsRepository
    {
        public ProductsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateProducts(Products products)
        {
            await Task.Run(() => Create(products));
        }

        public void DeleteProducts(Products products)
        {
            Delete(products);
        }

        public async Task<Products> GetProducttByCode(Guid productCode)
        {
            return await FindByCondition(x => x.ProductCode.Equals(productCode))
           .FirstOrDefaultAsync();
        }

        public async Task UpdateProducts(Products products)
        {
            await Task.Run(() => Update(products));
        }
    }
}
