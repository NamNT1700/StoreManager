using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects
{
    public class CustomersForUpdateDto
    {
        [Required(ErrorMessage = "CustomersNumber is required")]
        public int CustomersId { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string CustomersName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string ContactLastName { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string ContactFirstName { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        public Guid PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "SalesRepEmployeeNumber is required")]
        public int EmployeeIdFK { get; set; }
        [Required(ErrorMessage = "Credit is required")]
        public int CreditLimit { get; set; }
    }
}
