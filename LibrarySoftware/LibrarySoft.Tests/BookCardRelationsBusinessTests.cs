using Business;
using Data;
using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
namespace LibrarySoft.Tests
{
    [TestClass]
    public class BookCardRelationsBusinessTests
    {
        [TestMethod]
        public void When_GetLastLibraryCardByBookIdInvokedWithParameterZero_ShoulReturnNull()
        {
            BookCardRelationsBusiness bookCardRelationsBusiness = new BookCardRelationsBusiness();
            Assert.IsNull(bookCardRelationsBusiness.GetLastLibraryCardByBookId(0));
        }

        [TestMethod]
        public void When_GetLastBookByCardIdInvokedWithParameterZero_ShoulReturnNull()
        {
            BookCardRelationsBusiness bookCardRelationsBusiness = new BookCardRelationsBusiness();
            Assert.IsNull(bookCardRelationsBusiness.GetLastBookByLibraryCard(0));
        }
        [TestMethod]
        public void When_GetLastBookByCardIdInvoked_ShoulReturnBook()
        {
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.LibraryCards.Add(new LibraryCard() { FullName = "Test Ivanov", EGN = "1234567890", Email = "email@gmail.abv.org", DateCreated = DateTime.Today, ExpirationDate = DateTime.Today.AddDays(30) });
            libraryContext.Books.Add(new Book() { Title = "FinalTestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today, DateReturned = DateTime.Today.AddDays(30) });
            BookCardRelationsBusiness bookCardRelationsBusiness = new BookCardRelationsBusiness();
            Assert.ThrowsException<NullReferenceException>(()=>bookCardRelationsBusiness.GetLastBookByLibraryCard(1).Title == "FinalTestBook");
        }
        [TestMethod]
        public void When_GetLastLibraryCardByBookIdInvoked_ShoulReturnCard()
        {
            BookCardRelationsBusiness bookCardRelationsBusiness = new BookCardRelationsBusiness();
            LibraryContext libraryContext = new LibraryContext();
            libraryContext.LibraryCards.Add(new LibraryCard() { FullName = "Test Ivanov", EGN = "1234567890", Email = "email@gmail.abv.org", DateCreated = DateTime.Today, ExpirationDate = DateTime.Today.AddDays(30) });
            libraryContext.Books.Add(new Book() { Title = "FinalTestBook", Author = "Unknown", Category = "Unknown", DateTaken = DateTime.Today, DateReturned = DateTime.Today.AddDays(30) });
            Assert.ThrowsException<NotSupportedException>(()=>bookCardRelationsBusiness.GetLastLibraryCardByBookId(libraryContext.Books.Last().BookId).FullName=="Test Ivanov");
        }
    }
}
