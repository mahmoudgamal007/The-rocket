using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TheRocket.Entities.Products
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Colors=new();
            Sizes=new();
            ImgsUrls=new();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desctiption { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int Discount { get; set; }
        public string Brand { get; set; }
        public virtual List<Color> Colors { get; set; }
        public virtual List<Size> Sizes { get; set; }
        public virtual List<ImgUrl> ImgsUrls { get; set; }
    }
}