using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Base.Models
{
    public class Organization
    {
        public Guid Guid { get; set; }
        public string Company_name { get; set; }
        public string Billing_address { get; set; }
        public string Billing_address2 { get; set; }
        public string Billing_city { get; set; }
        public string Billing_state { get; set; }
        public string Billing_zip { get; set; }
        public Guid CRM_id { get; set; }
        virtual public ICollection<User> Users { get; set; }
        virtual public ICollection<License> Licenses { get; set; }
    }
}