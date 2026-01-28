using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;

namespace ProductApplication.Controllers
{
    public class ProductController : Controller
    {
        ProductBL productBL = new ProductBL();
        public IActionResult Index()
        {
            return View();
        }

        //An action that returns all products
        public IActionResult GetProductList()
        {
            List<Product> products = productBL.GetAllProducts();
            return View("ShowAll", products);
        }

        //An action that returns a single product by its ID
        public IActionResult GetById(int id)
        {
            Product product = productBL.GetProductById(id);

            //Error handling for invalid IDs
            if (product != null)
            {
                return View("ShowById", product);
            }

            return View("ProductDetailError");
            
        }
    }
}
