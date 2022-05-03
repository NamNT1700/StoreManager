using Entities.Models;
using System;

namespace Entities.DataTransferObjects
{
    public class OrdersDto
    {
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public string Status { get; set; }
        public string Comments { get; set; }
        public int CustomersFK { get; set; }
        virtual public Customers Customers { get; set; }
        virtual public OrderDetails OrderDetails { get; set; }
    }
}
