using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheRocket.Entities.Users
{
	public class Buyer
	{
		public Buyer()
		{
            Feedbacks = new();
            ReserveCarts = new();
            Orders = new();
		}

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }

        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }

        public virtual List<Feedback>? Feedbacks { get; set; }

        public virtual List<ReserveCart>? ReserveCarts { get; set; }

        public virtual List<Order>? Orders { get; set; }
    }

    public enum Gender
    {
        Male = 0, Female = 1
    }

}

