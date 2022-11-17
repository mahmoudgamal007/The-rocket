using TheRocket.Entities.Products;

namespace TheRocket.Dtos
{
    public class SubCategoryDto
    {
        public SubCategoryDto()
        {
            products = new();

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainCategory { get; set; }
        public virtual List<Product>? products { get; set; }
    }
}