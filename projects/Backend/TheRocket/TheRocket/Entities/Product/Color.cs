using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Products
{
    public class Colour:BaseEntity
    {
        public Colour()
        {
            ProductColors=new();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<ProductColor> ProductColors { get; set; }
    }
}