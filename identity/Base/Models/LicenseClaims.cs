using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Models
{
    public class LicenseClaims
    {
        public Guid Guid { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public Guid LicenseGuid { get; set; }
        virtual public License License { get; set; }
    }
}