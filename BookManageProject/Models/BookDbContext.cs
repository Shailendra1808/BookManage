using Microsoft.EntityFrameworkCore;

namespace BookManageProject.Models
{
    public class BookDbContext(DbContextOptions<BookDbContext>options):DbContext(options)
    {
        public DbSet<Book> Book { get; set;}
        public DbSet<BookData> BookData { get; set;}
    }
}
