using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Users
{
    public class Address:BaseEntity
    {
        [Key]
        public int Id{get; set;}
        public string Country { get; set; }
        public string Government { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}