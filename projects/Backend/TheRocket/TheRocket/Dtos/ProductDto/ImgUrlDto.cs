using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.ProductDtos
{
    public class ImgUrlDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
    }
}