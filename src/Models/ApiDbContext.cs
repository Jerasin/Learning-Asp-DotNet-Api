using Microsoft.EntityFrameworkCore;

namespace RestApiSample.Models
{


    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

        }


        public DbSet<User> User { get; set; } = null!;

        public DbSet<Product> Product { get; set; } = null!;

        public DbSet<WareHouse> WareHouse { get; set; } = null!;
    }
}
