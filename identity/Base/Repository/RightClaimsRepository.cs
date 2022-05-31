using Base.Contract;
using Base.Data;
using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Identity.Repository
{
    public class RightClaimsRepository : RepositoryBase<ProductClaim>, IRightClaimsRepository
    {
        public RightClaimsRepository(IdentityServerDbContext context) : base(context)
        {
        }
    }
}