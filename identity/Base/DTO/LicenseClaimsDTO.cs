using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public class LicenseClaimsDTO
    {
        public string Type { get; set; }
        public string Value { get; set; }
        public Guid LicenseGuid { get; set; }
    }
}