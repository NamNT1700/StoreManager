using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("products")]
    public class Products
    {
        [Required(ErrorMessage = "ProductCode is required")]
        public Guid ProductCode { get; set; }
        [Required(ErrorMessage = "ProductName is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "ProductLine is required")]
        public int ProductIdFK { get; set; }
        [Required(ErrorMessage = "ProductScale is required")]
        public string ProductScale { get; set; }
        [Required(ErrorMessage = "ProductVendor is required")]
        public string ProductVendor { get; set; }
        [Required(ErrorMessage = "ProductDiscription is required")]
        public string ProductDiscription { get; set; }
        [Required(ErrorMessage = "QuantityInStock is required")]
        public string QuantityInStock { get; set; }
        [Required(ErrorMessage = "BuyPrice is required")]
        public string BuyPrice { get; set; }
        [Required(ErrorMessage = "MSRP is required")]
        public string MSRP { get; set; }
        public ProductLines ProductLines { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
