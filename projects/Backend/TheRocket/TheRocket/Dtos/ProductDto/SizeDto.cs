using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Dtos.ProductDtos
{
    public class SizeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}