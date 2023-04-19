using Microsoft.EntityFrameworkCore;

namespace RestApiSample.Models
{


    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<Product>()
        //                 .HasOne<WareHouse>(product => product.WareHouse)
        //                 .WithOne(wareHouse => wareHouse.Product)
        //                 .HasForeignKey<WareHouse>(wareHouse => wareHouse.ProductId);
        // }


        public DbSet<User> User { get; set; } = null!;

        public DbSet<Product> Product { get; set; } = null!;

        public DbSet<WareHouse> WareHouse { get; set; } = null!;
    }
}
