using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.EntitiesUsers;

namespace TheRocket.Entities.Users
{
    public class Phone
    {
        [Key]
        public int Id { get; set; }
        [RegularExpression("01[0-2,5][0-9]{8}$")]
        public string phone { get; set; }
        [ForeignKey(nameof(user))]
        public int UserId { get; set; }
        public virtual User user { get; set; }
    }
}