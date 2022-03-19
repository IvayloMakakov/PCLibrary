using Business;
using Data;
using Data.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace LibrarySoft.Tests
{
    [TestClass]
    public class LibraryCardBusinessTests
    {
        private LibraryCard libraryCard = new LibraryCard() { FullName="Ivan Ivanov", EGN="1234567890", Email="email@gmail.abv.org", DateCreated=DateTime.Today,ExpirationDate=DateTime.Today.AddDays(30)};

        [TestMethod]
        public void When_CardAdded_ShouldHaveCountMoreThanZero()
        {
            LibraryCardBusiness libraryCardBusiness = new LibraryCardBusiness();
            libraryCardBusiness.AddCard(libraryCard);

            Assert.IsTrue(libraryCardBusiness.GetAllCards().Count() > 0);
        }

        [TestMethod]
        public void When_BookRemoved_ShouldHaveCountOne()
        {
            LibraryCardBusiness libraryCardBusiness = new LibraryCardBusiness();
            int count = libraryCardBusiness.GetAllCards().Count();
            libraryCardBusiness.AddCard(this.libraryCard);
            libraryCardBusiness.DeleteCard(this.libraryCard.Id);
            Assert.IsTrue(count == libraryCardBusiness.GetAllCards().Count());
        }

        [TestMethod]
        public void When_UpdateBookAndGetAllBooks_ShouldContainUpdatedValues()
        {
            LibraryCardBusiness libraryCardBusiness = new LibraryCardBusiness();
            libraryCardBusiness.AddCard(this.libraryCard);
            libraryCardBusiness.UpdateCard(new LibraryCard() {Id=this.libraryCard.Id, FullName = "Georgy Ivanov", EGN = "1234567890", Email = "email@gmail.abv.org", DateCreated = DateTime.Today, ExpirationDate = DateTime.Today.AddDays(30) });
            ;
            Assert.IsTrue(libraryCardBusiness.GetAllCards().Exists(x => x.FullName == "Georgy Ivanov"));
        }

        [TestMethod]
        public void When_GetBookWithIdInvoked_ShouldReturnFirstDeclaredBook()
        {
            LibraryCardBusiness libraryCardBusiness = new LibraryCardBusiness();
            libraryCardBusiness.AddCard(this.libraryCard);
            Assert.AreEqual("Ivan Ivanov", libraryCardBusiness.GetCardWithId(this.libraryCard.Id).FullName);
        }

        [TestMethod]
        public void When_SearchBookInvoked_ShouldReturnCollectionOfOneOrTwoBooks()
        {
            LibraryCardBusiness libraryCardBusiness = new LibraryCardBusiness();
            var collection = libraryCardBusiness.SearchCards("Georgy Ivanov");

            Assert.IsTrue(collection.Count >= 1);
        }
    }
}
