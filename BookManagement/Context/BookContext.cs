using BookManagement.Models.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Context
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options)
        : base(options) { }
        public DbSet<BookDAO> Books { get; set; }
        public DbSet<BookPriceDAO> BookPrices { get; set; }

    }
}
