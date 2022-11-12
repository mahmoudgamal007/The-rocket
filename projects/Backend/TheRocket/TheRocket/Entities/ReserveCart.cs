using System;
namespace TheRocket.Entities
{
    public class ReserveCart:BaseEntity
    {
        public int Quantity { get; set; }
        public bool IsSubmitted { get; set; }
    }
}
