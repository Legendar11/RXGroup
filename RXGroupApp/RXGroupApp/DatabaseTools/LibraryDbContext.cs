using RXGroupApp.Models;
using System.Data.Entity;

namespace RXGroupApp.DatabaseTools
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
            : base("DbConnection")
        { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<IssueBook> IssueBooks { get; set; }
    }
}