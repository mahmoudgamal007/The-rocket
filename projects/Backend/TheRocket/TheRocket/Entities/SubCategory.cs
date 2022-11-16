using System.ComponentModel.DataAnnotations;
using TheRocket.Entities.Products;

namespace TheRocket.Entities
{
    public class SubCategory:BaseEntity// menna
    {
        public SubCategory()
        {
            products = new();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainCategory { get; set; }
        public virtual List<Product>? products { get; set; }
    }
}