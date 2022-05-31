using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Base.Models
{
    public class License
    {
        [Key]
        public Guid? Guid { get; set; }

        public string ClientID { get; set; }
        public DateTime Expridate { get; set; }
        public DateTime ActiveDate { get; set; }
        public string State { get; set; }
        public Guid LicenseTypeId { get; set; }
        virtual public LicenseType LicenseType { get; set; }
        public Guid? OrganizationId { get; set; }
        virtual public Organization Organization { get; set; }
        public string UserGuid { get; set; }
        virtual public User User { get; set; }
        virtual public ICollection<LicenseClaims> LicenseClaims { get; set; }
    }
}