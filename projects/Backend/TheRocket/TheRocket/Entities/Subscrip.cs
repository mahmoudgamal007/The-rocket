using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Users;

namespace TheRocket.Entities
{
    public class Subscrip:BaseEntity
    {
        public bool IsActivated { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        [ForeignKey(nameof(Seller))]
        public int SellerId { get; set; }
        public virtual Seller Seller { get; set; }

        [ForeignKey(nameof(Plan))]
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }

    }
}
