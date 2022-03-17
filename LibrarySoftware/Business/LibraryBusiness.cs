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

        public void AddBook(Book book)
        {
            libraryContext.Books.Add(book);
            libraryContext.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            Book updatedBook = libraryContext.Books.Find(book.BookId);
            if (updatedBook != null)
            {
                libraryContext.Entry(updatedBook).CurrentValues.SetValues(book);
                libraryContext.SaveChanges();
            }
        }

        public void DeleteBook(int id)
        {
            Book product = libraryContext.Books.Find(id);
            if (product != null)
            {
                libraryContext.Books.Remove(product);
                libraryContext.SaveChanges();
            }
        }

        public void AddCard(LibraryCard card)
        {
            libraryContext.LibraryCards.Add(card);
            libraryContext.SaveChanges();
        }

        public void UpdateCard(LibraryCard card)
        {
            LibraryCard updatedCard = libraryContext.LibraryCards.Find(card.Id);
            if (updatedCard != null)
            {
                libraryContext.Entry(updatedCard).CurrentValues.SetValues(card);
                libraryContext.SaveChanges();
            }
        }

        public void DeleteCard(int id)
        {
            LibraryCard card = libraryContext.LibraryCards.Find(id);
            if (card != null)
            {
                libraryContext.LibraryCards.Remove(card);
                libraryContext.SaveChanges();
            }
        }

        public void CreateRelation(Book book, LibraryCard card)
        {

        }
    }
}
