using ProductApplication.Models;
using ProductApplication.ViewModels;
namespace ProductApplication.ModelsBL
{
    public class ProductBL
    {
        private readonly AppDbContext _db;

        public ProductBL()
        {
            _db = new AppDbContext();
        }

        public List<ProductListViewModel> GetAllProductsForList()
        {
            return _db.Products
                .Join(_db.Categories,
                        p => p.CategoryId,
                        c => c.Id,
                        (p, c) => new ProductListViewModel
                        {
                            Id = p.Id,
                            ProductName = p.ProductName,
                            ProductPrice = p.ProductPrice,
                            ImageUrl = p.ImageUrl,
                            CategoryName = c.CategoryName
                        })
                .ToList();
        }

        public Product? GetProductById(int productId)
        {
            return _db.Products.FirstOrDefault(p => p.Id == productId);
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            _db.Products.Remove(product);
            _db.SaveChanges();
        }
    }
}
