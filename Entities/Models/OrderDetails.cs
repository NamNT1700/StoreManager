using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("orderdetails")]
    public class OrderDetails
    {
        [Required(ErrorMessage = "OrderNumber is required")]
        public int OrderNumberFK { get; set; }
        [Required(ErrorMessage = "ProductCode is required")]
        public Guid ProductCodeFK { get; set; }
        [Required(ErrorMessage = "QuantityOrdered is required")]
        public int QuantityOrdered { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int PriceEach { get; set; }
        [Required(ErrorMessage = "OrderLineNumber is required")]
        public int OrderLineNumber { get; set; }
        public Products Products { get; set; }
        public Orders Orders { get; set; }



    }
}
