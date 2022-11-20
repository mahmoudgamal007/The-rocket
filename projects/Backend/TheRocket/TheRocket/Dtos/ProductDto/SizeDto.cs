using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.ProductDtos
{
    public class ProductSizeDto
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public int ProductId { get; set; }
    }
}