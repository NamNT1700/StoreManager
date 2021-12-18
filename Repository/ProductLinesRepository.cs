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
    public class ProductLinesRepository: RepositoryBase<ProductLines>, IProductLinesRepository
    {
        public ProductLinesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateProductLines(ProductLines productLines)
        {
            await Task.Run(()=> Create(productLines));
        }

        public void DeleteProductLines(ProductLines productLines)
        {
            Delete(productLines);
        }

        public async Task<ProductLines> GetProductbyLine(int producID)
        {
            return await FindByCondition(x => x.ProductId.Equals(producID))
            .FirstOrDefaultAsync();
        }

        public async Task UpdateProductLines(ProductLines productLines)
        {
            await Task.Run(() => Update(productLines));
        }
    }
}
