namespace ProiectPAW__MVC_.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int Quantity { get; set; }

        public virtual Order? Order { get; set; }
        public int? OrderId { get; set; }
        public virtual Product? Product { get; set; }
        public int? ProductId { get; set; }
    }
}
