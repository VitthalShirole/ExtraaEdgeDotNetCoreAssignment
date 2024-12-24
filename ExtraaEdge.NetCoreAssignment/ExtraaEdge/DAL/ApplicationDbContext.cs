using ExtraaEdge.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdge.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HandSet> handSet { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
    }
}
