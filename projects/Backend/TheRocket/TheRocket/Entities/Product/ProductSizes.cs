using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Products
{
    public class ProductSize
    {
        [ForeignKey(nameof(size))]
        public int SizeId { get; set; }
        public virtual Size size { get; set; }

        [ForeignKey(nameof(product))]
        public int ProductId { get; set; }
        public virtual Product product { get; set; }

        public DateTime CreatedAt { get; set; }=DateTime.Now;
    }
}