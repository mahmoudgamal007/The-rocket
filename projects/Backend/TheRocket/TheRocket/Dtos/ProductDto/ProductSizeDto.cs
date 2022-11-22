namespace TheRocket.Dtos.ProductDtos
{
    public class ProductSizeDto
    {
        public ProductSizeDto()
        {
            SizeIds=new();
        }
        public int ProductId { get; set; }
        public List<int> SizeIds { get; set; }
    }
}