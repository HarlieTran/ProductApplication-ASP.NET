using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProductApplication.Models;
using ProductApplication.ModelsBL;
using ProductApplication.ViewModels;    

namespace ProductApplication.Controllers
{
    public class ProductController : Controller
    {
        ProductBL productBL = new ProductBL();

        // List all products
        public IActionResult Index()
        {
            List<ProductListViewModel> products = productBL.GetAllProductsForList();
            ViewBag.msg = TempData["msg"];

            return View("Index", products);
        }

        // Show the form to create a new product
        public IActionResult Create()
        {
            ProductCreateViewModel viewModel = new ProductCreateViewModel
            {
                Categories = new CategoryBL().GetAllCategories()
            };

            ViewBag.msg = TempData["msg"];

            return View(viewModel);
        }

        // Handle the form submission to create a new product
        [HttpPost]
        public IActionResult SaveCreate(ProductCreateViewModel formModel)
        {
            // Validate the form data
            if (formModel.ProductName == null || 
                formModel.ProductPrice <= 0 ||
                formModel.CategoryId == 0)
            {
                TempData["msg"] = "Please provide valid product information.";
                return RedirectToAction("Create", formModel);
            }

            // Map the form data to a Product model
            Product formProduct = new Product
            {
                ProductName = formModel.ProductName,
                ProductPrice = formModel.ProductPrice,
                ImageUrl = formModel.ImageUrl,
                Description = formModel.Description,
                CategoryId = formModel.CategoryId
            };

            // Save the new product using the business logic layer
            productBL.AddProduct(formProduct);
            TempData["msg"] = $"Product {formProduct.ProductName} added successfully!";

            return RedirectToAction("Index");
        }

        // Show the form to edit an existing product
        public IActionResult Edit(int id)
        {
            Product? product = productBL.GetProductById(id);

            // Check if the product exists
            if (product == null)
            {
                TempData["msg"] = $"Product not found.";
                return RedirectToAction("Index");
            }

            ProductEditViewModel formModel = new ProductEditViewModel
            {
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                Categories = new CategoryBL().GetAllCategories(),
                CategoryId = product.CategoryId

            };

            ViewBag.msg = TempData["msg"];

            return View("Edit", formModel);
        }

        // Handle the form submission to edit an existing product
        [HttpPost]
        public IActionResult SaveEdit(ProductEditViewModel formModel)
        {
            // Validate the form data
            if (formModel.ProductName == null || formModel.ProductPrice <= 0)
            {
                TempData["msg"] = "Please provide valid product name and price.";
                return RedirectToAction("Edit", formModel);
            }

            // Retrieve the existing product from the database
            Product existingProduct = productBL.GetProductById(formModel.Id);

            // Check if the product exists
            if (existingProduct == null)
            {
                TempData["msg"] = $"Product not found.";
                return RedirectToAction("Index");
            }

            // Map the form data to the existing product model
            existingProduct.ProductName = formModel.ProductName;
            existingProduct.ProductPrice = formModel.ProductPrice;
            existingProduct.ImageUrl = formModel.ImageUrl;
            existingProduct.Description = formModel.Description;
            existingProduct.CategoryId = formModel.CategoryId;

            // Update the product using the business logic layer
            productBL.UpdateProduct(existingProduct);
            TempData["msg"] = $"Product {existingProduct.ProductName} updated successfully!";

            return RedirectToAction("Index");
        }

        // Handle the request to delete a product
        public IActionResult Delete(int id)
        {
            Product? product = productBL.GetProductById(id);

            // Check if the product exists
            if (product == null)
            {
                TempData["msg"] = $"Product not found.";
                return RedirectToAction("Index");
            }

            // Delete the product using the business logic layer
            productBL.DeleteProduct(product);
            TempData["msg"] = $"Product {product.ProductName} deleted successfully!";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Product? product = productBL.GetProductById(id);

            // Check if the product exists
            if (product == null)
            {
                TempData["msg"] = $"Product not found.";
                return RedirectToAction("Index");
            }

            ProductListViewModel viewModel = new ProductListViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                ImageUrl = product.ImageUrl,
                Description = product.Description,
                CategoryName = new CategoryBL().GetCategoryById(product.CategoryId)?.CategoryName

            };

            return View("Details", viewModel);
        }
    }
}
