using Microsoft.EntityFrameworkCore;
using Base.Contract;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Base.Data;

namespace Server.Identity.Repository
{
    public class LicenseRepository : RepositoryBase<License>, ILicenseRepository
    {
        private IdentityServerDbContext _context;

        public LicenseRepository(IdentityServerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<License> FindLicenseByUserId(string userID)
        {
            License license = await FindByCondition(x => x.UserGuid.Equals(userID)).FirstOrDefaultAsync();
            return license;
        }

        public async Task<License> FindLicenseByOrgId(Guid orgID)
        {
            License license = await FindByCondition(x => x.OrganizationId.Equals(orgID)).FirstOrDefaultAsync();
            return license;
        }

        public async Task<License> FindLicenseByUserId(string userID, string ClientId)
        {
            License license = await _context.Set<License>().Where(x => x.UserGuid.Equals(userID) &&
                                                                       x.ClientID.Equals(ClientId))
                                                            .Include(l => l.LicenseClaims)
                                                            .Include(l => l.LicenseType)
                                                            .ThenInclude(ltpc => ltpc.LicenseTypeProductClaims)
                                                            .ThenInclude(lt => lt.ProductClaim)
                                                            .FirstOrDefaultAsync();
            return license;
        }

        public async Task<IEnumerable<ProductClaim>> FindAllOrgClaim(Guid orgId)
        {
            License license = await _context.Set<License>().Where(x => x.OrganizationId.Equals(orgId))
                                                            .Include(l => l.LicenseType)
                                                            .ThenInclude(ltpc => ltpc.LicenseTypeProductClaims)
                                                            .ThenInclude(lt => lt.ProductClaim)
                                                            .FirstOrDefaultAsync();
            return license.LicenseType.LicenseTypeProductClaims.ToList().ConvertAll(x => x.ProductClaim);
        }
    }
}