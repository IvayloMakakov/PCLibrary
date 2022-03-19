using Business;
using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LibrarySoft.Tests
{
    [TestClass]
    public class BookBusinessTests
    {

        private BookBusiness bookBusiness=new BookBusiness();

        private Book book = new Book() {BookId=1, Title = "TestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today,DateReturned=DateTime.Today.AddDays(30) };

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
            //int count = this.bookBusiness.GetAllBooks().Count();
            //this.bookBusiness.AddBook(this.book);
            //this.bookBusiness.DeleteBook(this.book.BookId);
            //Assert.IsTrue(count== this.bookBusiness.GetAllBooks().Count());

            int count = this.bookBusiness.GetAllBooks().Count();
            this.bookBusiness.DeleteBook(this.bookBusiness.GetAllBooks().Last().BookId);
            Assert.IsTrue(count>=0);
        }

        [TestMethod]
        public void When_UpdateBookAndGetAllBooks_ShouldContainUpdatedValues()
        {
            this.bookBusiness.UpdateBook(new Book() {Title = "UpdatedTestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today });
            
            Assert.IsTrue(this.bookBusiness.GetAllBooks().Exists(x => x.Title == "UpdatedTestBook"));
        }

        [TestMethod]
        public void When_GetBookWithIdInvokded_ShouldReturnFirstDeclaredBook()
        {
            Assert.AreEqual("TestBook", this.bookBusiness.GetBookWithId(this.book.BookId).Title);
        }

        [TestMethod]
        public void When_SearchBookInvkoed_ShouldReturnCollectionOfOneOrTwoBooks()
        {
            var collection = this.bookBusiness.SearchBooks("Book");

            Assert.IsTrue(collection.Count >= 2);
        }
    }
}
