using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Users;

namespace TheRocket.Entities.Products
{
    public class Product : BaseEntity
    {
        public Product()
        {
            Colors = new();
            Sizes = new();
            ImgsUrls = new();
            Feedbacks = new();
            ReserveCarts = new();
            Orders = new();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Brand { get; set; }

        [ForeignKey(nameof(SubCategory))]
        public int SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }



        public virtual List<ProductColor>? Colors { get; set; }
        public virtual List<ProductSize>? Sizes { get; set; }
        public virtual List<ImgUrl> ImgsUrls { get; set; }
        public virtual List<Feedback>? Feedbacks { get; set; }
        public virtual List<ReserveCart>? ReserveCarts { get; set; }
        public virtual List<Order>? Orders { get; set; }
    }
}