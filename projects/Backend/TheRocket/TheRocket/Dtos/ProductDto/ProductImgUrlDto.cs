

using System.ComponentModel.DataAnnotations;

namespace TheRocket.Dtos.ProductDtos
{
    public class ProductImgUrlDto
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; }
        public int ProductId { get; set; }
    }
}