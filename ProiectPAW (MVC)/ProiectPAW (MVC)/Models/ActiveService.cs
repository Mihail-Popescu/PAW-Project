namespace ProiectPAW__MVC_.Models
{
    public class ActiveService
    {
        public int? ActiveServiceId { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }

        public virtual OrderItem? Plan { get; set; }
        public int? OrderItemId { get; set; }
    }
}
