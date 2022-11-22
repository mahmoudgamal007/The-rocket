namespace TheRocket.Dtos.ProductDtos
{
    public class ProductColorDto
    {
        public ProductColorDto()
        {
            ColourIds = new();
        }
        public int ProductId { get; set; }
        public List<int> ColourIds { get; set; }
    }
}