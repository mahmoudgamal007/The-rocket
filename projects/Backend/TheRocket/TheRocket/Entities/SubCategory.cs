using System.ComponentModel.DataAnnotations;

namespace TheRocket.Entities
{
    public class SubCategory:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainCategory { get; set; }
        
    }
}