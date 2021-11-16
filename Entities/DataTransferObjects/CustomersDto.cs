using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CustomersDto
    {
        
        public int CustomersNumber { get; set; }
        public string Name { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Guid PostalCode { get; set; }
        public string Country { get; set; }
        public int SalesRepEmployeeNumber { get; set; }
        public int Credit { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
