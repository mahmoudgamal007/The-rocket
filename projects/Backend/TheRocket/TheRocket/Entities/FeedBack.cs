using System.ComponentModel.DataAnnotations;
namespace TheRocket.Entities
{
    public class Feedback:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string? Comment { get; set; }
        [Range(1,5)]
        public int Rating { get; set; }

    }
}
