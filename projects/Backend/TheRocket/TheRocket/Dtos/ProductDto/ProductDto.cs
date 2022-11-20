using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Users;

namespace TheRocket.Entities.ProductDtos
{
    public class ProductDto
    {
     
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Brand { get; set; }

        public int SubCategoryId { get; set; }
        public int SellerId { get; set; }



        public ProductColorDto? Color { get; set; }
        public ProductSizeDto? Size { get; set; }
        public ImgUrlDto? ImgsUrl { get; set; }
        public Feedback? Feedback { get; set; }
        public ReserveCart? ReserveCart { get; set; }
        public Order? Orders { get; set; }
    }
}