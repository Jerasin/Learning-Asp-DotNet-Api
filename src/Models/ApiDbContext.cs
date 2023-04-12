using Microsoft.EntityFrameworkCore;

namespace Models.ApiDbContext
{
    using Models.User;

    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) { }


        public DbSet<User> User { get; set; } = null!;
    }
}
