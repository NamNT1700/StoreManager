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
        public string OrderNumber { get; set; }
       
        public Guid City { get; set; }
        [Required(ErrorMessage = "QuantityOrdered is required")]
        public int QuantityOrdered { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        [Required(ErrorMessage = "OrderLineNumber is required")]
        public int OrderLineNumber { get; set; }


        [ForeignKey(nameof(Products))]
        public Guid ProductCode { get; set; }
        public Products Products { get; set; }
        [ForeignKey(nameof(Orders))]
        public int orderNumber { get; set; }
        public Orders Orders { get; set; }



    }
}
