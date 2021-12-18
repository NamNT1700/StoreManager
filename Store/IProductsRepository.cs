using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IProductsRepository: IRepositoryBase<Products>
    {
        Task CreateProducts(Products products);
        Task UpdateProducts(Products products);
        void DeleteProducts(Products products);
        Task<Products> GetProducttByCode(Guid productCode);
    }
}
