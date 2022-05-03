using Entities.Models;
using System;

namespace Entities.DataTransferObjects.OrdersDetailsDTO
{
    public class OrderDetailsDto
    {

        public int OrderNumberFK { get; set; }
        public Guid ProductCodeFK { get; set; }
        public int QuantityOrdered { get; set; }
        public int PriceEach { get; set; }
        public int OrderLineNumber { get; set; }
        public Products Products { get; set; }
        public Orders Orders { get; set; }
    }
}
