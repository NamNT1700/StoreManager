using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("payments")]
    public class Payments
    {
        [Required(ErrorMessage = "CustomerNumber is required")]
        public int CustomersIdFK { get; set; }
        [Required(ErrorMessage = "CheckNumber is required")]
        public int CheckNumber { get; set; }
        [Required(ErrorMessage = "PaymentDate is required")]
        public DateTime PaymentDate { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }
        public Customers Customers { get; set; }
    }
}
