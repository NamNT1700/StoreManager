using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    [Table("productlines")]
    public class ProductLines
    {
        [Required(ErrorMessage = "ProductLine is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "TextDescription is required")]
        public string TextDescription { get; set; }
        [Required(ErrorMessage = "HtmlDescription is required")]
        public string HtmlDescription { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
        public ICollection<Products> Products { get; set; }

    }
}
