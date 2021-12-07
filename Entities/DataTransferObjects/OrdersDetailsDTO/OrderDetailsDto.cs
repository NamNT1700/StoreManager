using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.OrdersDetailsDTO
{
    public class OrderDetailsDto
    {
        
        public int OrderNumber { get; set; }
       
        public Guid ProductCode { get; set; }
      
        public int QuantityOrdered { get; set; }
     
        public int PriceEach { get; set; }
      
        public int OrderLineNumber { get; set; }
        public Products Products { get; set; }
        public Orders Orders { get; set; }
    }
}
