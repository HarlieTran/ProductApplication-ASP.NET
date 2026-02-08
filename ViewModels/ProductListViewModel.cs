namespace ProductApplication.ViewModels
{
    public class ProductListViewModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        // Category name only (no dropdown)
        public string CategoryName { get; set; }
    }
}