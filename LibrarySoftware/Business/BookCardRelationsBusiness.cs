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
        /*public ICollection<BookCardRelations> GetRelationsByBookId(int bookId)
        {
            ///////????????????????????
            return null;
        }*/
    }
}
