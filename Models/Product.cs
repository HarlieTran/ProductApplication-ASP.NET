using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        public double ProductPrice { get; set; }

        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
