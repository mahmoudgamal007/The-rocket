using TheRocket.Entities;

namespace TheRocket.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public bool IsReturned { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public bool ReturnRequest { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductId { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
 

    }
}
