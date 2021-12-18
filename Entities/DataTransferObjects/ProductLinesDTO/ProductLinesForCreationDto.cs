using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.DataTransferObjects.ProductLinesDTO
{
    public class ProductLinesForCreationDto
    {
        [Required(ErrorMessage = "ProductLine is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "TextDescription is required")]
        public string TextDescription { get; set; }
        [Required(ErrorMessage = "HtmlDescription is required")]
        public string HtmlDescription { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public string Image { get; set; }
    }
}
