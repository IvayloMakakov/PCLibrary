using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Model;

namespace Business
{
    /// <summary>
    /// Represents the set of functionality of the GUI elements at program startup
    /// </summary>
    public class BookBusiness
    {
        private LibraryContext libraryContext;

        /// <summary>
        /// Initiates a new instance of the BookBusiness class by setting specific initial values
        /// </summary>
        public BookBusiness()
        {
            this.libraryContext = new LibraryContext();
        }
        /// <summary>
        /// Gets all books from database
        /// </summary>
        /// <returns> Collection of Books </returns>
        public List<Book> GetAllBooks()
        {
            return libraryContext.Books.ToList();
        }
        /// <summary>
        /// Gets a book by specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Element of Book type</returns>
        public Book GetBookWithId(int id)
        {
            return libraryContext.Books.Find(id);
        }
        /// <summary>
        /// Search for a specific books by their title
        /// </summary>
        /// <param name="searchedText"></param>
        /// <returns>Collection of Books</returns>
        public List<Book> SearchBooks(string searchedText)
        {
            List<Book> foundBooks = new List<Book>();
            foreach (Book book in this.GetAllBooks())
            {
                if (book.Title.ToLower().Contains(searchedText.ToLower()))
                {
                    foundBooks.Add(book);
                }
                else if (book.Author.ToLower().Contains(searchedText.ToLower()))
                {
                    foundBooks.Add(book);
                }
                else if (book.Category.ToLower().Contains(searchedText.ToLower()))
                {
                    foundBooks.Add(book);
                }
            }
            return foundBooks;
        }
        /// <summary>
        /// Adds a book to the current context
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            libraryContext.Books.Add(book);
            libraryContext.SaveChanges();
        }
        /// <summary>
        /// Updates a book to the current context
        /// </summary>
        /// <param name="book"></param>
        public void UpdateBook(Book book)
        {
            Book updatedBook = libraryContext.Books.Find(book.BookId);
            if (updatedBook != null)
            {
                libraryContext.Entry(updatedBook).CurrentValues.SetValues(book);
                libraryContext.SaveChanges();
            }
        }
        /// <summary>
        /// Delets a book to the current context
        /// </summary>
        /// <param name="id"></param>
        public void DeleteBook(int id)
        {
            Book product = libraryContext.Books.Find(id);
            if (product != null)
            {
                libraryContext.Books.Remove(product);
                libraryContext.SaveChanges();
            }
        }
    }
}
