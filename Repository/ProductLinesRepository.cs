using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Store;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductLinesRepository : RepositoryBase<ProductLines>, IProductLinesRepository
    {
        public ProductLinesRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task CreateProductLines(ProductLines productLines)
        {
            await Task.Run(() => Create(productLines));
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
