using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Products
{
    public class ProductImgUrl:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}