using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public class LicenseTypeDTO
    {
        public int OfflineRange { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public Guid ProductID { get; set; }
        public List<LicenseTypeProductClaimDTO> LicenseTypeProductClaims { get; set; }
    }

    public class LicenseTypeEditDTO
    {
        public int OfflineRange { get; set; }
        public List<LicenseTypeProductClaimDTO> LicenseTypeProductClaims { get; set; }
    }
}