using Business;
using Data;
using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySoft.Tests
{
    [TestClass]
    public class BookBusinessTests
    {

        private BookBusiness bookBusiness = new BookBusiness();      
        private Book book = new Book() {Title = "TestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today,DateReturned=DateTime.Today.AddDays(30) };

        [TestMethod]
        public void When_BookAdded_ShouldHaveCountMoreThanZero()
        {
            //this.bookBusiness = new BookBusiness();


            this.bookBusiness.AddBook(this.book);

            Assert.IsTrue(this.bookBusiness.GetAllBooks().Count() > 0);
        }

        [TestMethod]
        public void When_BookRemoved_ShouldHaveCountOne()
        {
            int count = this.bookBusiness.GetAllBooks().Count();
            this.bookBusiness.AddBook(this.book);
            this.bookBusiness.DeleteBook(this.book.BookId);
            Assert.IsTrue(count == this.bookBusiness.GetAllBooks().Count());
        }

        [TestMethod]
        public void When_UpdateBookAndGetAllBooks_ShouldContainUpdatedValues()
        {
            this.bookBusiness.AddBook(this.book);
            this.bookBusiness.UpdateBook(new Book() {BookId = this.book.BookId, Title = "UpdatedTestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today });
            
            Assert.IsTrue(this.bookBusiness.GetAllBooks().Exists(x => x.Title == "UpdatedTestBook"));
        }

        [TestMethod]
        public void When_GetBookWithIdInvoked_ShouldReturnFirstDeclaredBook()
        {
            this.bookBusiness.AddBook(this.book);
            Assert.AreEqual("TestBook", this.bookBusiness.GetBookWithId(this.book.BookId).Title);
        }

        [TestMethod]
        public void When_SearchBookInvoked_ShouldReturnCollectionOfOneOrTwoBooks()
        {
            this.bookBusiness.AddBook(this.book);
            List<Book> collection = this.bookBusiness.SearchBooks("Book");

            Assert.IsTrue(collection.Count >= 1);
        }
    }
}
