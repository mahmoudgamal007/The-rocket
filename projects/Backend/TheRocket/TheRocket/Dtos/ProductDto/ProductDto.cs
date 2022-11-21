using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.ProductDtos
{
    public class ProductDto
    {
     
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Desctiption { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Brand { get; set; }

        public int SubCategoryId { get; set; }
        [Required]
        public int SellerId { get; set; }



        public ProductColorDto? productColorDtos { get; set; }
        public ProductSizeDto? productSizeDtos { get; set; }
        [Required]
        public ProductImgUrlDto ProductImgUrlDto { get; set; }
   
    }
}