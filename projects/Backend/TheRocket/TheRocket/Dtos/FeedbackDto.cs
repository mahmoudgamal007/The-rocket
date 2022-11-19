using System.ComponentModel.DataAnnotations;

namespace TheRocket.Dtos
{
    public class FeedbackDto
    {
        public string Comment { get; set; }
        [Range(1, 5)]
        public int Rating { get; set; }

    }
}
