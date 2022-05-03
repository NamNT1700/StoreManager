using Entities.Models;
using System.Threading.Tasks;

namespace Store
{
    public interface IProductLinesRepository : IRepositoryBase<ProductLines>
    {
        Task CreateProductLines(ProductLines productLines);
        Task UpdateProductLines(ProductLines productLines);
        void DeleteProductLines(ProductLines productLines);
        Task<ProductLines> GetProductbyLine(int producID);
    }
}
