using System.ComponentModel.DataAnnotations;

namespace TheRocket.Dtos.UserDtos
{
    public class PhoneDto
    {
         public int Id { get; set; }
        [RegularExpression("01[0-2,5][0-9]{8}$")]
        public string phone { get; set; }
        public string AppUserId { get; set; }
    }
}