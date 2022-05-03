using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public DateTime ShippedDate { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Comment date is required")]
        public string Comments { get; set; }
        [Required(ErrorMessage = "CustomersNumber is required")]
        public int CustomersFK { get; set; }
        virtual public Customers Customers { get; set; }
        virtual public OrderDetails OrderDetails { get; set; }
    }
}
