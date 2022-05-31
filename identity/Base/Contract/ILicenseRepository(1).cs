using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Base.Models;

namespace Base.Contract
{
    public interface ILicenseRepository : IRepositoryBase<License>
    {
        public Task<License> FindLicenseByUserId(string userID, string ClientId);

        public Task<License> FindLicenseByOrgId(Guid orgID);

        public Task<License> FindLicenseByUserId(string userID);

        public Task<IEnumerable<ProductClaim>> FindAllOrgClaim(Guid orgId);
    }
}