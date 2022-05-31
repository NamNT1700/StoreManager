using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Models
{
    public class LicenseType
    {
        public Guid guid { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public int OfflineRange { get; set; }
        public virtual ICollection<LicenseTypeProductClaim> LicenseTypeProductClaims { get; set; }
        public Guid LicenseId { get; set; }
        public ICollection<License> Licenses { get; set; }
    }
}