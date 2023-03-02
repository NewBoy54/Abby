using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Model
{
    public class AbbyCategoryDbContext : DbContext
    {
        
        public AbbyCategoryDbContext(DbContextOptions<AbbyCategoryDbContext> options) : base(options)
        {

        }
        

        public DbSet<AbbyCategory> AbbyCategories { get; set; }
    }
}
