using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Models
{
    public class ProductClaim
    {
        [ForeignKey(nameof(License))]
        public Guid LicenseTypeId { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Guid guid { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public virtual ICollection<LicenseTypeProductClaim> LicenseTypeProductClaims { get; set; }
    }
}