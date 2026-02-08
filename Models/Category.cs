using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
