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
        public IActionResult ShowProductList()
        {
            List<Product> products = productBL.GetAllProducts();
            return View("ShowAll", products);
        }

        public IActionResult ProductDetail(int id)
        {
            Product product = productBL.GetProductById(id);

            if(product != null)
            {
                return View("ShowById", product);
            }

            return View("ProductDetailError");
            
        }
    }
}
