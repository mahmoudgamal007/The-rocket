using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TheRocket.Entities.Products;

namespace TheRocket.Entities.Users
{
    public class Seller
    {
        public Seller()
        {
            Orders = new();
            Products = new();
            Subscrips = new();
        }

        [Key]
        public int Id { get; set; }
        public string ReferalCode { get; set; }
        public int Points { get; set; }
        public string About { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public string BrandName { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string AppUserId{ get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual List<Order>? Orders { get; set; }
        public virtual List<Subscrip>? Subscrips { get; set; }
        public virtual List<Product>? Products { get; set; }
    }
}
