using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.EntitiesUsers;

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

        [ForeignKey(nameof(user))]
        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}