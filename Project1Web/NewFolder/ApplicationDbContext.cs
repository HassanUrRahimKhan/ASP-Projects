using Microsoft.EntityFrameworkCore;
using Project1Web.Models;

namespace Project1Web.NewFolder
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Category> categories { get; set;  }
    }
}
