using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos
{
    public class FeedbackDto
    {
        public string Comment { get; set; }
        
        [Range(1, 5)]
        public int Rating { get; set; }
        public int BuyerId { get; set; }
        public int ProductId { get; set; }

    }
}
