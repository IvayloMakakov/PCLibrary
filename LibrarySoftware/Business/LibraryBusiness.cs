using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            return this.libraryContext.Books.ToList();
        }

        public Book GetBookWithId(int id)
        {
            return this.libraryContext.Books.Find(id);
        }

        public List<LibraryCard> GetAllCards()
        {
            return this.libraryContext.LibraryCards.ToList();
        }

        public LibraryCard GetCardWithId(int id)
        {
            return this.libraryContext.LibraryCards.Find(id);
        }

        public void AddBook(Book book)
        {
            try
            {
                this.libraryContext.Books.Add(book);
                this.libraryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when adding a book.");
            }

        }

        public void UpdateBook(Book book)
        {
            try
            {
                Book updatedBook = this.libraryContext.Books.Find(book.BookId);
                if (updatedBook != null)
                {
                    this.libraryContext.Entry(updatedBook).CurrentValues.SetValues(book);
                    this.libraryContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when updating a book.");
            }

        }

        public void DeleteBook(int id)
        {
            try
            {
                Book product = this.libraryContext.Books.Find(id);
                if (product != null)
                {
                    this.libraryContext.Books.Remove(product);
                    this.libraryContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when deleting a book.");
            }

        }

        public void AddCard(LibraryCard card)
        {

            try
            {
                this.libraryContext.LibraryCards.Add(card);
                this.libraryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when adding a card.");
            }
        }

        public void UpdateCard(LibraryCard card)
        {
            try
            {
                LibraryCard updatedCard = this.libraryContext.LibraryCards.Find(card.Id);
                if (updatedCard != null)
                {
                    this.libraryContext.Entry(updatedCard).CurrentValues.SetValues(card);
                    this.libraryContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when updating a card.");
            }


        }

        public void DeleteCard(int id)
        {

            try
            {
                LibraryCard card = this.libraryContext.LibraryCards.Find(id);
                if (card != null)
                {
                    this.libraryContext.LibraryCards.Remove(card);
                    this.libraryContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when deleting a card.");
            }
        }

        public void DeleteExpiredCard(LibraryCard card)
        {
            if (card.ExpirationDate < DateTime.Today)
            {
                this.DeleteCard(card.Id);
            }
        }

        public void CreateRelation(Book book, LibraryCard card)
        {
            try
            {
                BookCardRelations relations = new BookCardRelations();
                relations.BookId = book.BookId;
                relations.Book = book;
                relations.LibraryCardId = card.Id;
                relations.LibraryCard = card;
                this.libraryContext.BookCardRelations.Add(relations);
                this.libraryContext.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when creating a relation.");
            }

        }
    }
}
