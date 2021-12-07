using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class CustomersForUpdateDto
    {
        [Required(ErrorMessage = "CustomersNumber is required")]
        public int CustomersNumber { get; set; }
        [Required(ErrorMessage = "Name is required")]
        public string CustomersName { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string ContactLastName { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string ContactFirstName { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }
        public Guid PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "SalesRepEmployeeNumber is required")]
        public int SalesRepEmployeeNumber { get; set; }
        [Required(ErrorMessage = "Credit is required")]
        public int CreditLimit { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Payments> Payments { get; set; }
        public Employees Employees { get; set; }
    }
}
