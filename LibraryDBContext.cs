using LibraryWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryWebApi.Data
{
    public class LibraryDBContext:DbContext
    {
        public LibraryDBContext(DbContextOptions<LibraryDBContext> options)
            :base(options) 
        {
        }
        public DbSet<Book> Books { get; set; }
    }
}
