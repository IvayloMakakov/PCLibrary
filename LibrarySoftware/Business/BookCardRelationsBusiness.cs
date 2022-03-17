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
        public ICollection<BookCardRelations> GetRelationsByBookId(int bookId)
        {
            ///////????????????????????
            return null;
        }
    }
}
