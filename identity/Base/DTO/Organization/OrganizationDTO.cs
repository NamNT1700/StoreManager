using System;
using System.Collections.Generic;
using System.Text;

namespace Base.DTO.Organization
{
    public class OrganizationCreateDTO
    {
        public string Company_name { get; set; }
        public string Billing_address { get; set; }
        public string Billing_address2 { get; set; }
        public string Billing_city { get; set; }
        public string Billing_state { get; set; }
        public string Billing_zip { get; set; }
        public Guid CRM_id { get; set; }
    }
    public class OrganizationGetDTO
    {
        public Guid Guid { get; set; }
        public string Company_name { get; set; }
        public string Billing_address { get; set; }
        public string Billing_address2 { get; set; }
        public string Billing_city { get; set; }
        public string Billing_state { get; set; }
        public string Billing_zip { get; set; }
        public Guid CRM_id { get; set; }
    }
    public class OrganizationUpdateDTO
    {
        public Guid Guid { get; set; }
        public string Company_name { get; set; }
        public string Billing_address { get; set; }
        public string Billing_address2 { get; set; }
        public string Billing_city { get; set; }
        public string Billing_state { get; set; }
        public string Billing_zip { get; set; }
        public Guid CRM_id { get; set; }
    }
}
