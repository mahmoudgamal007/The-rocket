using TheRocket.Entities.Products;

namespace TheRocket.Dtos
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainCategory { get; set; }
    }
}