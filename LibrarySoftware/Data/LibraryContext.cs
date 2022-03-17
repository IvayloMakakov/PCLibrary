using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Model;

namespace Data
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<BookCardRelations> BookCardRelations { get; set; }

        public LibraryContext() : base("name=Library")
        {

        }
    }
}
