using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Users
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}