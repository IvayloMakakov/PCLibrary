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
        private BookBusiness bookBusiness;
        private Book book = new Book() { Title = "TestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today };

        [TestMethod]
        public void When_BookAdded_ShouldHaveCountMoreThanZero()
        {
            this.bookBusiness = new BookBusiness();

            this.bookBusiness.AddBook(this.book);

            Assert.IsTrue(this.bookBusiness.GetAllBooks().Count() > 0);
        }

        [TestMethod]
        public void When_BookRemoved_ShouldHaveCountOne()
        {
            this.bookBusiness.DeleteBook(1);

            Assert.IsTrue(this.bookBusiness.GetAllBooks().Count() == 1);
        }

        [TestMethod]
        public void When_UpdateBookAndGetAllBOoks_ShouldContainUpdatedValues()
        {
            this.bookBusiness.UpdateBook(new Book() { Title = "UpdatedTestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today });
            
            Assert.IsTrue(this.bookBusiness.GetAllBooks().Exists(x => x.Title == "UpdatedTestBook"));
        }

        [TestMethod]
        public void When_GetBookWithIdInvokded_ShouldReturnFirstDeclaredBook()
        {
            Assert.AreEqual("TestBook", this.bookBusiness.GetBookWithId(1).Title);
        }

        [TestMethod]
        public void When_SearchBookInvkoed_ShouldReturnCollectionOfOneOrTwoBooks()
        {
            var collection = this.bookBusiness.SearchBooks("Book");

            Assert.IsTrue(collection.Count >= 2);
        }
    }
}
