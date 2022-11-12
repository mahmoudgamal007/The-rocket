using System.ComponentModel.DataAnnotations;

namespace TheRocket.Entities
{
    public class Subscrip:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public bool IsActivated { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
