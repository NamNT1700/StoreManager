using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Models
{
    public class LicenseTypeProductClaim
    {
        public Guid LicenseTypeId { get; set; }
        public LicenseType LicenseType { get; set; }
        public Guid ProductClaimId { get; set; }
        public ProductClaim ProductClaim { get; set; }
    }
}