using ProductApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.ViewModels
{
    public class ProductCreateViewModel
    {
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        [Display(Name = "Price")]
        public double ProductPrice { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        // Dropdown list
        public List<Category> Categories { get; set; }
    }
}