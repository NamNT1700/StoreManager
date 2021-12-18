using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class ProductsRepository: RepositoryBase<Products>, IProductsRepository
    {
        public ProductsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateProducts(Products products)
        {
           await Task.Run( ()=>Create(products));
        }

        public void DeleteProducts(Products products)
        {
            Delete(products);
        }

        public async Task<Products> GetProducttByCode(Guid productCode)
        {
            return await  FindByCondition(x => x.ProductCode.Equals(productCode))
           .FirstOrDefaultAsync();
        }

        public async Task UpdateProducts(Products products)
        {
            await Task.Run(() => Update(products));
        }
    }
}
