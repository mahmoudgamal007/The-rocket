

using TheRocket.Dtos.ProductDtos;

namespace TheRocket.Dtos
{
    public class ReserveCartDto //mennas
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public bool IsSubmitted { get; set; }
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public  ProductDto? Product { get; set; }
    }
}
