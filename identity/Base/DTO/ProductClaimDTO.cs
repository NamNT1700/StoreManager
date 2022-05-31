using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public class ProductClaimDTO
    {
        public Guid ProductId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }

    public class ProductClaimsDTO
    {
        public Guid ProductId { get; set; }
        public string ClaimType { get; set; }
        public IEnumerable<string> ClaimValues { get; set; }
    }
}