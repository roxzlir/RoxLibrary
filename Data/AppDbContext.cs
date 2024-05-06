using Microsoft.EntityFrameworkCore;
using RoxLibrary.Models;

namespace RoxLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
    }
}
