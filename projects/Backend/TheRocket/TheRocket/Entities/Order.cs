using System;
namespace TheRocket.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string DeliveryStatus { get; set; }
        public bool IsReturned { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public bool ReturnRequest { get; set; }



    }
}
