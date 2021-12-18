using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DataTransferObjects.ProductDTO
{
    public class ProductDto
    {

        public Guid ProductCode { get; set; }
        public string ProductName { get; set; }
        public int ProductIdFK { get; set; }
        public string ProductScale { get; set; }
        public string ProductVendor { get; set; }
        public string ProductDiscription { get; set; }
        public string QuantityInStock { get; set; }
        public string BuyPrice { get; set; }
        public string MSRP { get; set; }
        public ProductLines ProductLines { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
