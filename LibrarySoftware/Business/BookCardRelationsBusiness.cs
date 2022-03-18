using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Model;

namespace Business
{
    public class BookCardRelationsBusiness
    {
        private LibraryContext libraryContext;

        public BookCardRelationsBusiness()
        {
            this.libraryContext = new LibraryContext();
        }

        public void CreateRelation(BookCardRelations bookCardRelations)
        {
            libraryContext.BookCardRelations.Add(bookCardRelations);
            libraryContext.SaveChanges();
        }

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
