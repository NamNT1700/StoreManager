using Base.Contract;
using Base.Data;
using Base.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.Repository
{
    public class LicenseTypeRepository : RepositoryBase<LicenseType>, ILicenseTypeRepository
    {
        private IdentityServerDbContext _context;

        public LicenseTypeRepository(IdentityServerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LicenseType>> GetAllLicenseTypeByProductId(Guid productId)
        {
            IEnumerable<LicenseType> LicenseTypes = await FindByCondition(x => x.ProductID.Equals(productId)).ToListAsync();
            return LicenseTypes;
        }
    }
}