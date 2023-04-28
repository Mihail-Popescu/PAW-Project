namespace ProiectPAW__MVC_.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public int? Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public virtual Category? Category { get; set; }
        public int CategoryId { get; set; }
    }
}
