using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    [Table("payments")]
    public class Payments
    {
        [Required(ErrorMessage = "CustomerNumber is required")]
        public string CustomersNumber { get; set; }
        [Required(ErrorMessage = "CheckNumber is required")]
        public string CheckNumber { get; set; }
        [Required(ErrorMessage = "PaymentDate is required")]
        public string PaymentDate { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public string Amount { get; set; }
        [ForeignKey(nameof(Customers))]
        public int customersNumber { get; set; }
        public Customers Customers { get; set; }
    }
}
