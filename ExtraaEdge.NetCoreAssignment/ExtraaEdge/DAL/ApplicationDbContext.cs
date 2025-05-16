using ExtraaEdge.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HandSet> handSet { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sales> Sales { get; set; }

        public DbSet<User> Users { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
