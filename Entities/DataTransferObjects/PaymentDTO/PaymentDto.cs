using Entities.Models;
using System;

namespace Entities.DataTransferObjects.PaymentDTO
{
    public class PaymentDto
    {

        public int CustomersIdFK { get; set; }
        public int CheckNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public int Amount { get; set; }
        public Customers Customers { get; set; }
    }
}
