using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Products
{
    public class Size:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<ProductSize>? ProductSizes { get; set; }

    }
}