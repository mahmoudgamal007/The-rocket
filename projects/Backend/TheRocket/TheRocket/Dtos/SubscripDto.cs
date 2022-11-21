using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities;
using TheRocket.Entities.Products;
using TheRocket.Entities.Users;

namespace TheRocket.Dtos
{
    public class SubscripDto
    {
        public int Id { get; set; }
        public bool IsActivated { get; set; }
        public int Discount { get; set; }
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int SellerId { get; set; }
        public int PlanId { get; set; }

    }
}
