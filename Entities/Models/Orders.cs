using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    [Table("orders")]
    public class Orders
    {
        [Required(ErrorMessage = "Order number is required")]
        public int OrderNumber { get; set; }
        [Required(ErrorMessage = "Order date is required")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Required date is required")]
        public DateTime RequiredDate { get; set; }
        [Required(ErrorMessage = "Ship date is required")]
        public DateTime ShipDate { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Comment date is required")]
        public string Comments { get; set; }
        [Required(ErrorMessage = "CustomersNumber is required")]
        public int CustomersNumber { get; set; }

        [ForeignKey(nameof(Customers))]
        public int customersNumber { get; set;  }
        public Customers Customers { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
