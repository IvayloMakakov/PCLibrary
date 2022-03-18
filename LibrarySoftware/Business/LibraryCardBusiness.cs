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
    public class LibraryCardBusiness
    {
        private LibraryContext libraryContext;

        /// <summary>
        /// Initiates a new instance of the LibraryCardBusiness class by setting specific initial values
        /// </summary>
        public LibraryCardBusiness()
        {
            this.libraryContext = new LibraryContext();
        }

        /// <summary>
        /// Gets all cards from database
        /// </summary>
        /// <returns> Collection of LibraryCards </returns>
        public List<LibraryCard> GetAllCards()
        {
            return libraryContext.LibraryCards.ToList();
        }
        /// <summary>
        /// Gets a card by specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Element of LibraryCard type</returns>
        public LibraryCard GetCardWithId(int id)
        {
            return libraryContext.LibraryCards.Find(id);
        }
        /// <summary>
        ///  Search for a specific books by specific input
        /// </summary>
        /// <param name="searchedText"></param>
        /// <returns></returns>
        public List<LibraryCard> SearchCards(string searchedText)
        {
            List<LibraryCard> foundCards = new List<LibraryCard>();
            foreach (LibraryCard card in this.GetAllCards())
            {
                if (card.FullName.ToLower().Contains(searchedText.ToLower()))
                {
                    foundCards.Add(card);
                }
                else if (card.EGN.ToLower().Contains(searchedText.ToLower()))
                {
                    foundCards.Add(card);
                }
                else if (card.Email.ToLower().Contains(searchedText.ToLower()))
                {
                    foundCards.Add(card);
                }
            }
            return foundCards;
        }

        public void AddCard(LibraryCard card)
        {
            libraryContext.LibraryCards.Add(card);
            libraryContext.SaveChanges();
        }

        public void UpdateCard(LibraryCard card)
        {
            LibraryCard updatedCard = libraryContext.LibraryCards.Find(card.Id);
            if (updatedCard != null)
            {
                libraryContext.Entry(updatedCard).CurrentValues.SetValues(card);
                libraryContext.SaveChanges();
            }
        }

        public void DeleteCard(int id)
        {
            LibraryCard card = libraryContext.LibraryCards.Find(id);
            if (card != null)
            {
                libraryContext.LibraryCards.Remove(card);
                libraryContext.SaveChanges();
            }
        }

        public void DeleteExpiredCard(LibraryCard card)
        {
            if (card.ExpirationDate < DateTime.Today)
            {
                this.DeleteCard(card.Id);
            }
        }


    }
}
