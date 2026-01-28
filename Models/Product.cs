namespace ProductApplication.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; } = string.Empty;
        public double ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
