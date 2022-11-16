using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Users;

namespace TheRocket.Entities
{
    public class Plan:BaseEntity//Mahmoud
    {
        public Plan()
        {
            Subscrips = new();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Duration { get; set; }
        public int Discount { get; set; }
        public virtual List<Subscrip>? Subscrips { get; set; }
    }
}
