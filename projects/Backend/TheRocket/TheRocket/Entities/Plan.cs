namespace TheRocket.Entities
{
    public class Plan
    {
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public int Duration { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Discount { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; } 

    }
}
