using Microsoft.EntityFrameworkCore;

namespace BooksDB_Gabriel_Viinikka.Models
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) :base(options)
        {

        }




    }
}
