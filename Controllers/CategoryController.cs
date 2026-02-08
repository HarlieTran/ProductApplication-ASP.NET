using Microsoft.AspNetCore.Mvc;
using ProductApplication.Models;
using ProductApplication.ModelsBL;
using ProductApplication.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ProductApplication.Controllers
{
    public class CategoryController : Controller
    {
        CategoryBL categoryBL = new CategoryBL();

        //  List all categories 
        public IActionResult Index()
        {
            List<Category> categories = categoryBL.GetAllCategories();
            ViewBag.msg = TempData["msg"];

            return View("Index", categories);
        }

        // Create a new category
        public IActionResult Create()
        {
            return View();
        }

        // Save the new category
        [HttpPost]
        public IActionResult SaveCreate(Category formCategory)
        {
            // Validate the form data
            if (formCategory.CategoryName == null)
            {
                TempData["msg"] = "Category Name is required!";
                return RedirectToAction("Create");
            }

            // Save the new category to the database
            categoryBL.AddCategory(formCategory);
            TempData["msg"] = $"Category {formCategory.CategoryName} added successfully!";

            return RedirectToAction("Index");
        }

        // Edit an existing category
        public IActionResult Edit(int id)
        {
            Category? category = categoryBL.GetCategoryById(id);

            // Check if the category exists
            if (category == null)
            {
                TempData["msg"] = $"Category not found!";
                return RedirectToAction("Index");
            }

            return View("Edit", category);
        }

        // Save the edited category
        [HttpPost]
        public IActionResult SaveEdit(Category formCategory)
        {
            // Validate the form data
            if (formCategory.CategoryName == null)
            {
                TempData["msg"] = "Category Name is required!";
                return RedirectToAction("Edit", formCategory);
            }

            // Update the category in the database
            Category? dbCategory = categoryBL.GetCategoryById(formCategory.Id);
            dbCategory.CategoryName = formCategory.CategoryName;
            dbCategory.Description = formCategory.Description;

            // Save the updated category
            categoryBL.UpdateCategory(dbCategory);
            TempData["msg"] = $"Category {dbCategory.CategoryName} updated successfully!";

            return RedirectToAction("Index");
        }

        // Delete an existing category
        public IActionResult Delete(int id)
        {
            Category? category = categoryBL.GetCategoryById(id);

            // Check if the category exists
            if (category == null)
            {
                TempData["msg"] = $"Category not found!";
                return RedirectToAction("Index");
            }

            // Delete the category from the database
            categoryBL.DeleteCategory(category);
            TempData["msg"] = $"Category {category.CategoryName} deleted successfully!";

            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Category? category = categoryBL.GetCategoryById(id);

            // Check if the category exists
            if (category == null)
            {
                TempData["msg"] = $"Category not found!";
                return RedirectToAction("Index");
            }

            // Create a view model to pass the category and its products to the view
            CategoryProductsViewModel viewModel = new CategoryProductsViewModel
            {
                CategoryName = category.CategoryName,
                Products = categoryBL.GetProductsByCategory(id)
            };

            return View("Details", viewModel);
        }
    }
}
