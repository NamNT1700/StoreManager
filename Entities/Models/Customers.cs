using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("customers")]
    public class Customers
    {
        [Required(ErrorMessage = "Number of customer is required")]
        public int CustomersNumber { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "LastName is required")]
        public string LName { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FName { get; set; }
        [Required(ErrorMessage = "PhoneNumber is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address cannot be longer than 100 characters")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        public Guid PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "SalesRepEmployeeNumber is required")]
        public int SalesRepEmployeeNumber { get; set; }
        [Required(ErrorMessage = "Credit is required")]
        public int Credit { get; set; }
        public ICollection<Orders> Orders { get; set; }
        public ICollection<Payments> Payments { get; set; }
        [ForeignKey(nameof(Employees))]
        public int salesRepEmployeeNumber { get; set; }
        public Employees Employees { get; set; }

    }
}

