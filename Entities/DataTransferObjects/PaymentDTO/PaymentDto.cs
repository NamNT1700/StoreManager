using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.PaymentDTO
{
    public class PaymentDto
    {
        
        public int CustomersNumber { get; set; }
       
        public int CheckNumber { get; set; }
      
        public DateTime PaymentDate { get; set; }
       
        public int Amount { get; set; }
        public Customers Customers { get; set; }
    }
}
