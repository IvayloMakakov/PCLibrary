﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Model;

namespace Business
{
    public class BookBusiness
    {
        private LibraryContext libraryContext;
        public BookBusiness()
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
    }
}