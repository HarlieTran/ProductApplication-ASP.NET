namespace ProductApplication.Models
{
    public class ProductBL
    {
        public List<Product> Products { get; set; }

        public ProductBL()
        {
            Products = new List<Product>
            {
                new Product
                {
                    Id = 1,
                    ProductName = "iPhone 15",
                    ProductPrice = 1199.99,
                    Description = "Latest Apple smartphone with an advanced camera system and A16 Bionic chip.",
                    Category = "Smartphone",
                    ImageUrl = "iphone15.png"
                },
                new Product
                {
                    Id = 2,
                    ProductName = "AirPods Pro",
                    ProductPrice = 349.99,
                    Description = "Premium wireless earbuds featuring active noise cancellation and spatial audio.",
                    Category = "Audio",
                    ImageUrl = "airpodspro.png"
                },
                new Product
                {
                    Id = 3,
                    ProductName = "iPad Air",
                    ProductPrice = 799.99,
                    Description = "Lightweight and powerful tablet designed for work, creativity, and entertainment.",
                    Category = "Tablet",
                    ImageUrl = "ipadair.png"
                },
                new Product
                {
                    Id = 4,
                    ProductName = "MacBook Air",
                    ProductPrice = 1499.99,
                    Description = "Ultra‑thin laptop with long battery life and fast performance.",
                    Category = "Laptop",
                    ImageUrl = "macbookair.png"
                },
                new Product
                {
                    Id = 5,
                    ProductName = "Apple Watch 9",
                    ProductPrice = 599.99,
                    Description = "Smartwatch with fitness tracking, health monitoring, and seamless iPhone integration.",
                    Category = "Wearable",
                    ImageUrl = "applewatch9.png"
                }
            };
        }
        public List<Product> GetAllProducts()
        {
            return Products;
        }
        public Product GetProductById(int id)
        {
            return Products.Find(p => p.Id == id);
        }
    }
}
