using System;
using System.Collections.Generic;
using System.Text;
using Entities.Models;

namespace Store
{
    public interface IProductLinesRepository: IRepositoryBase<ProductLines>
    {
        void CreateProductLines(ProductLines productLines);
        void UpdateProductLines(ProductLines productLines);
        void DeleteProductLines(ProductLines productLines);
    }
}
