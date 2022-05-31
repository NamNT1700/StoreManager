using Base.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManager.DTO
{
    public class LicenseDTO
    {
        public string ClientID { get; set; }
        public DateTime Expridate { get; set; }
        public Guid LicenseTypeId { get; set; }
        public Guid? OrganizationId { get; set; }
        public string UserGuid { get; set; }
    }

    public class LicenseUpdateDTO
    {
        public DateTime Expridate { get; set; }
        public Guid LicenseTypeId { get; set; }
        public IEnumerable<LicenseClaimsDTO> LicenseClaims { get; set; }
    }
}