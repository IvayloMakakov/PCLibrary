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
    public class BookCardRelationsBusiness
    {
        private LibraryContext libraryContext;


        /// <summary>
        /// Initiates a new instance of the BookCardRelationsBusiness class by setting specific initial values
        /// </summary>

        public BookCardRelationsBusiness()
        {
            this.libraryContext = new LibraryContext();
        }

        /// <summary>
        /// Creates a relation
        /// </summary>
        /// <param name="bookCardRelations"></param>
        public void CreateRelation(BookCardRelations bookCardRelations)
        {
            libraryContext.BookCardRelations.Add(bookCardRelations);
            libraryContext.SaveChanges();
        }
        /// <summary>
        /// Gets the last library card by specific id
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public LibraryCard GetLastLibraryCardByBookId(int bookId)
        {
            List<int> libraryCardsId = libraryContext.BookCardRelations.Where(r => r.BookId == bookId).Select(r => r.LibraryCardId).ToList();
            if (libraryCardsId.Count == 0)
            {
                return null;
            }

            LibraryCardBusiness libraryCardBusiness = new LibraryCardBusiness();
            return libraryCardBusiness.GetCardWithId(libraryCardsId.Last());
        }
        /// <summary>
        /// Gets the last book by specific id
        /// </summary>
        /// <param name="cardId"></param>
        /// <returns></returns>
        public Book GetLastBookByLibraryCard(int cardId)
        {
            List<int> booksId = libraryContext.BookCardRelations.Where(r => r.LibraryCardId == cardId).Select(r => r.BookId).ToList();
            if (booksId.Count == 0)
            {
                return null;
            }

            BookBusiness bookBusiness = new BookBusiness();
            return bookBusiness.GetBookWithId(booksId.Last());
        }
    }
}
