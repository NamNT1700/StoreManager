using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class CustomersForCreationDto
    {
       
        public int CustomersId { get; set; }
     
        public string CustomersName { get; set; }
       
        public string ContactLastName { get; set; }
      
        public string ContactFirstName { get; set; }
       
        public string Phone { get; set; }
        
        public string Address { get; set; }
       
        public string City { get; set; }
       
        public string State { get; set; }
        public Guid PostalCode { get; set; }
      
        public string Country { get; set; }

        public int EmployeeIdFK { get; set; }
        public int CreditLimit { get; set; }
    }
}
