using System;
using System.ComponentModel.DataAnnotations;

namespace TheRocket.Entities
{
    public class Order:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string DeliveryStatus { get; set; }//need to be enum
        public bool IsReturned { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Quantity { get; set; }
        public bool ReturnRequest { get; set; }

    }
}
