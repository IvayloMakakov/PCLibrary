using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class LibraryBusiness
    {
        private LibraryContext libraryContext;

        public LibraryBusiness()
        {
            this.libraryContext = new LibraryContext();
        }

        public List<Book> GetAllBooks()
        {
            return libraryContext.Books.ToList();
        }

        public Book GetBookWithId(int id)
        {
            return libraryContext.Books.Find(id);
        }

        public List<LibraryCard> GetAllCards()
        {
            return libraryContext.LibraryCards.ToList();
        }

        public LibraryCard GetCardWithId(int id)
        {
            return libraryContext.LibraryCards.Find(id);
        }
    }
}
