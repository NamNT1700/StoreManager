using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.OrdersDetailsDTO
{
    public class OrderDetailsForCreationDto
    {
        [Required(ErrorMessage = "OrderNumber is required")]
        public int OrderNumber { get; set; }
        [Required(ErrorMessage = "ProductCode is required")]
        public Guid ProductCode { get; set; }
        [Required(ErrorMessage = "QuantityOrdered is required")]
        public int QuantityOrdered { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public int PriceEach { get; set; }
        [Required(ErrorMessage = "OrderLineNumber is required")]
        public int OrderLineNumber { get; set; }
        //public Products Products { get; set; }
        //public Orders Orders { get; set; }
    }
}
