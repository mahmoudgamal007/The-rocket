using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.Entities
{
    public class Order:BaseEntity//mahmoud
    {
        [Key]
        public int Id { get; set; }
        public DeliveryStatus DeliveryStatus { get; set; }
        public bool IsReturned { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public bool ReturnRequest { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Buyer))]
        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }

        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }



    }

    public enum DeliveryStatus
    {
        Stock=0,Shipping=1,Delivvered=2
    }
}
