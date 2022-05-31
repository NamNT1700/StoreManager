using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Contract
{
    public interface ILicenseTypeRepository : IRepositoryBase<LicenseType>
    {
        public Task<IEnumerable<LicenseType>> GetAllLicenseTypeByProductId(Guid productId);
    }
}