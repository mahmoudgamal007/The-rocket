using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos.ProductDtos
{
    public class GetAllProductDto
    {
        public GetAllProductDto()
        {
            products=new();
        }
     
       public List<ProductDto> products; 
       public int productMatchCount { get; set; }
       public int startIndex { get; set; }
       public int endIndex { get; set; }
       public int productPerPage { get; set; }
   
    }
}