using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.DataTransferObjects.OrdersDetailsDTO
{
    public class OrderDetailsForUpdateDto
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
    }
}
