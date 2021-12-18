using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Store
{
    public interface IProductLinesRepository: IRepositoryBase<ProductLines>
    {
        Task CreateProductLines(ProductLines productLines);
        Task UpdateProductLines(ProductLines productLines);
        void DeleteProductLines(ProductLines productLines);
        Task<ProductLines> GetProductbyLine(int producID);
    }
}
