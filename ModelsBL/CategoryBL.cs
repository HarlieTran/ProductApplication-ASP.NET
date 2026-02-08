using ProductApplication.Models;

namespace ProductApplication.ModelsBL
{
    public class CategoryBL
    {
        private readonly AppDbContext _db;
        public CategoryBL()
        {
            _db = new AppDbContext();
        }
        public List<Category> GetAllCategories()
        {
            return _db.Categories.ToList();
        }
        public Category? GetCategoryById(int categoryId)
        {
            return _db.Categories.FirstOrDefault(c => c.Id == categoryId);
        }
        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _db.Products.Where(p => p.CategoryId == categoryId).ToList();
        }
        public void AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }
        public void UpdateCategory(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }
        public void DeleteCategory(Category category)
        { 
            _db.Categories.Remove(category);
            _db.SaveChanges();
        }
    }
}
