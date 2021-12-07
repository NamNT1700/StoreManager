using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.OfficesDTO
{
    public class OfficesDto
    {
       
        public string OfficeCode { get; set; }
     
        public string City { get; set; }
     
        public string Phone { get; set; }
     
        public string Address { get; set; }

        public string State { get; set; }
      
        public string Country { get; set; }
  
        public string PostalCode { get; set; }
   
        public string Territory { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
