using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Products
{
    public class ProductColor:BaseEntity
    {
        [ForeignKey(nameof(Colour))]
        public int ColourId { get; set; }
        public virtual Colour Colour { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}