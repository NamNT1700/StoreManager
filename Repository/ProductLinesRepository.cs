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
    }
}
