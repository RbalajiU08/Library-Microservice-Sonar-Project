using BookServices.Model;
using Microsoft.EntityFrameworkCore;

namespace BookServices.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
