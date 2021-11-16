using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects
{
    public class OrdersDto
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int CustomersNumber { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
