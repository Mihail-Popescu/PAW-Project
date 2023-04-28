namespace ProiectPAW__MVC_.Models
{
    public class Order
    {
        public int? OrderId { get; set; }
        public DateTime? OrderDate { get; set; }
        public float? TotalPrice { get; set; }

        public virtual Customer? Customer { get; set; }
        public int? CustomerId { get; set; }
    }
}
