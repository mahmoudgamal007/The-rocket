using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Users
{
    public class Location:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Longitude { get; set; }
        public string Latitude{get; set;}

        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}