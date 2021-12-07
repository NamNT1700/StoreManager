using Entities;
using Store;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Repository
{
    public class ProductLinesRepository: RepositoryBase<ProductLines>, IProductLinesRepository
    {
        public ProductLinesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public void CreateProductLines(ProductLines productLines)
        {
            Create(productLines);
        }

        public void DeleteProductLines(ProductLines productLines)
        {
            Delete(productLines);
        }

        public void UpdateProductLines(ProductLines productLines)
        {
            Update(productLines);
        }
    }
}
