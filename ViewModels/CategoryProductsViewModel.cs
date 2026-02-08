using System.ComponentModel.DataAnnotations;
using ProductApplication.Models;

namespace ProductApplication.ViewModels
{
    public class CategoryProductsViewModel
    {

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }

    }
}
