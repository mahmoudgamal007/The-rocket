using System.ComponentModel.DataAnnotations;

namespace TheRocket.Entities
{
    public class Subscrip:BaseEntity
    {
        [Key]
        public int SubscripId { get; set; }//Just Id
        public bool IsSubscribed { get; set; }//IsActivated
        public int DisCount { get; set; }//Discount
        public decimal Price { get; set; }//Double
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
