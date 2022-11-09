using System.ComponentModel.DataAnnotations;
namespace TheRocket.Entities
{
    public class FeedBack
    {
        [Key]
        public int FeedBack_Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }

    }
}
