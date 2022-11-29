using System.ComponentModel.DataAnnotations;

namespace TheRocket.Dtos
{
    public class FeedbackDto
    {
        public int Id { get; set;}
        public string Comment { get; set; }
        
        [Range(1, 5)]
        public int Rating { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
