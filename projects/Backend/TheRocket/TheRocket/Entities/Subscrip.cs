using System.ComponentModel.DataAnnotations;

namespace TheRocket.Entities
{
    public class Subscrip
    {
        [Key]
        public int SubscripId { get; set; }
        public bool IsSubscribed { get; set; }
        public int DisCount { get; set; }
        public decimal Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
