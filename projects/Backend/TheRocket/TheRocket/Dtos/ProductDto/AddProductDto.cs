using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.ProductDtos
{
    public class AddProductDto
    {
     
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Desctiption { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double Price { get; set; }
        public int Discount { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public int SubCategoryId { get; set; }
        [Required]
        public int SellerId { get; set; }

        public List<int> ColorIds { get; set; }
        public List<int> SizeIds { get; set; }
        public List<string>? ImgUrls { get; set; }
   
    }
}