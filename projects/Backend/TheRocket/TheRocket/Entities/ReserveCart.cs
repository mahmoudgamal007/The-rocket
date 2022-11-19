using System;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.Entities
{
    public class ReserveCart:BaseEntity//mennas
    {
        public int Quantity { get; set; }
        public bool IsSubmitted { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(Buyer))]
        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }
    }
}
