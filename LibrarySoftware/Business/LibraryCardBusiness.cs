using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Model;

namespace Business
{
    public class LibraryCardBusiness
    {
        private LibraryContext libraryContext;

        public LibraryCardBusiness()
        {
            this.libraryContext = new LibraryContext();
        }


        public List<LibraryCard> GetAllCards()
        {
            return libraryContext.LibraryCards.ToList();
        }

        public LibraryCard GetCardWithId(int id)
        {
            return libraryContext.LibraryCards.Find(id);
        }

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
