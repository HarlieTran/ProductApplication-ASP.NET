using Microsoft.EntityFrameworkCore;

namespace ProductApplication.Models
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=localhost;
                Initial Catalog=ProductDb;
                Integrated Security=True;
                Encrypt=False;");
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
