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

        


<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        public ProductColorDto? productColorDtos { get; set; }
        public ProductSizeDto? productSizeDtos { get; set; }
        [Required]
        public ProductImgUrlDto ProductImgUrlDto { get; set; }
=======
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9

        public List<ColorDto> Colors { get; set; }
        public List<SizeDto> Sizes { get; set; }
        [Required]
        public List<ProductImgUrlDto> Imgs { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
=======
>>>>>>> 3a18350ded735fc0d173dce8cf72c8ff8c23eba9
   
    }
}