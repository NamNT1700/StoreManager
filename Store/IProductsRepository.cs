using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public interface IProductsRepository: IRepositoryBase<Products>
    {
        void CreateProducts(Products products);
        void UpdateProducts(Products products);
        void DeleteProducts(Products products);
    }
}
