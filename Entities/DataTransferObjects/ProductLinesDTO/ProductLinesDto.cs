using Entities.Models;
using System.Collections.Generic;

namespace Entities.DataTransferObjects.ProductLinesDTO
{
    public class ProductLinesDto
    {

        public int ProductId { get; set; }
        public string TextDescription { get; set; }
        public string HtmlDescription { get; set; }
        public string Image { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
