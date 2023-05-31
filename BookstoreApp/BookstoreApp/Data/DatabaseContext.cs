using BookstoreApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApp.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }
        public DbSet<Book> Books { get; set;}
        public DbSet<User> Users { get; set;}
        public DbSet<Booking> Bookings { get; set;}
    }
}
