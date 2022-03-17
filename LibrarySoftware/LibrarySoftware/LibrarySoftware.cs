using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business;
using Data.Model;

namespace LibrarySoftware
{
    public partial class FormLibrarySoftware : Form
    {
        public BookBusiness bookBusiness;
        public LibraryCardBusiness cardBusiness;
        public BookCardRelationsBusiness relationsBusiness;

        public FormLibrarySoftware()
        {
            InitializeComponent();
            comboBoxSelection.SelectedIndex = 0;
            this.bookBusiness = new BookBusiness();
            this.cardBusiness = new LibraryCardBusiness();
            this.relationsBusiness = new BookCardRelationsBusiness();
            this.UpdateGrid();
            foreach (var card in this.cardBusiness.GetAllCards())
            {
                comboBoxTakenByWho.Items.Add(card.Id + ", " + card.FullName);
            }
            this.SetDates();
            foreach (LibraryCard card in cardBusiness.GetAllCards())
            {
                cardBusiness.DeleteExpiredCard(card);
            }
        }

        private void comboBoxSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelection.Text == "Books")
            {
                groupBoxBook.Visible = true;
                Point point = new Point(groupBoxCard.Location.X + 1000, groupBoxCard.Location.Y);
                groupBoxCard.Location = point;
            }
            else
            {
                groupBoxBook.Visible = false;
                groupBoxCard.Location = groupBoxBook.Location;
            }
        }

        private void checkBoxTaken_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTaken.Checked)
            {
                labelDateTaken.Visible = true;
                labelReturnDate.Visible = true;
                dateTimePickerReturn.Visible = true;
                dateTimePickerTaken.Visible = true;
                labelTakenBy.Visible = true;
                comboBoxTakenByWho.Visible = true;
            }
            else
            {
                labelDateTaken.Visible = false;
                labelReturnDate.Visible = false;
                dateTimePickerReturn.Visible = false;
                dateTimePickerTaken.Visible = false;
                labelTakenBy.Visible = false;
                comboBoxTakenByWho.Visible = false;
            }
        }

        private void dateTimePickerTaken_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerReturn.Value = dateTimePickerTaken.Value.AddDays(30);
        }

        private void dateTimePickerDateCreated_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerExpirationDate.Value = dateTimePickerDateCreated.Value.AddYears(1);
        }

        private void SetDates()
        {
            dateTimePickerReturn.Value = dateTimePickerTaken.Value.AddDays(30);
            dateTimePickerExpirationDate.Value = dateTimePickerDateCreated.Value.AddYears(1);
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                Book book = new Book();
                book.Title = textBoxTitle.Text;
                book.Author = textBoxAuthor.Text;
                book.Category = textBoxCategory.Text;
                if (checkBoxTaken.Checked)
                {
                    book.DateTaken = dateTimePickerTaken.Value;
                    book.DateReturned = dateTimePickerReturn.Value;
                    int cardId = int.Parse(comboBoxTakenByWho.Text.Split(',').ToArray()[0]);
                    LibraryCard libraryCard = cardBusiness.GetAllCards().Where(x => x.Id == cardId).First();

                    BookCardRelations bookCardRelation = new BookCardRelations();

                    bookBusiness.AddBook(book);

                    bookCardRelation.LibraryCardId = libraryCard.Id;
                    bookCardRelation.BookId = book.BookId;

                    this.relationsBusiness.CreateRelation(bookCardRelation);
                }
                else
                {
                    book.DateTaken = null;
                    book.DateReturned = null;
                    bookBusiness.AddBook(book);
                }



                UpdateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the add book button.");
            }

        }

        private void UpdateGrid()
        {
            try
            {
                this.dataGridViewBooks.DataSource = this.bookBusiness.GetAllBooks();
                this.dataGridViewCards.DataSource = this.cardBusiness.GetAllCards();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when updating data grid.");
            }
        }

        private void buttonAddNewCard_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryCard card = new LibraryCard();

                card.FullName = textBoxFullName.Text;
                card.EGN = textBoxEgn.Text;
                card.Email = textBoxEmail.Text;
                card.DateCreated = dateTimePickerDateCreated.Value;
                card.ExpirationDate = dateTimePickerExpirationDate.Value;

                this.cardBusiness.AddCard(card);
                UpdateGrid();
                comboBoxTakenByWho.Items.Add(card.Id + ", " + card.FullName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the add new card button.");
            }

        }

        private void pictureBoxMagnifyingGlass_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCellCollection row = dataGridViewBooks.SelectedRows[0].Cells;
                int id = (int)row[0].Value;
                bookBusiness.DeleteBook(id);
                UpdateGrid();
                dataGridViewBooks.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the delete book button.");
            }

        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDeleteCard_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewCellCollection row = dataGridViewCards.SelectedRows[0].Cells;
                int id = (int)row[0].Value;
                cardBusiness.DeleteCard(id);
                UpdateGrid();
                dataGridViewBooks.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the delete card button.");
            }
        }

        private void FormLibrarySoftware_Load(object sender, EventArgs e)
        {

        }

        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewBooks.SelectedRows.Count > 0)
            {
                var item = dataGridViewBooks.SelectedRows[0].Cells;
                int id = (int)item[0].Value;
                UpdateTextBoxesBooks(id);
                buttonEditBook.Visible = false;
                buttonSaveBook.Visible = true;
                dataGridViewBooks.Enabled = false;
                UpdateGrid();
            }

        }


        private void UpdateTextBoxesBooks( int id)
        {
            Book book = this.bookBusiness.GetBookWithId(id);
            textBoxTitle.Text = book.Title;
            textBoxAuthor.Text= book.Author;
            textBoxCategory.Text= book.Category;
            if (checkBoxTaken.Checked)
            {
                dateTimePickerTaken.Value = book.DateTaken.Value;
            }
            else
            {
                dateTimePickerTaken.Value = DateTime.Today;                
            }
            SetDates();
        }

        private void buttonEditCard_Click(object sender, EventArgs e)
        {
            if (dataGridViewCards.SelectedRows.Count > 0)
            {
                var item = dataGridViewCards.SelectedRows[0].Cells;
                int id = (int)item[0].Value;
                UpdateTextBoxesCards(id);
            }
        }

        private void UpdateTextBoxesCards(int id)
        {
            LibraryCard card = this.cardBusiness.GetCardWithId(id);
            textBoxFullName.Text = card.FullName;
            textBoxEgn.Text = card.EGN;
            textBoxEmail.Text= card.Email;
            dateTimePickerDateCreated.Value=card.DateCreated;
            dateTimePickerExpirationDate.Value=card.ExpirationDate;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var item = dataGridViewCards.SelectedRows[0].Cells;
            int id = (int)item[0].Value;
            Book book = new Book();
            book.BookId = id;
            book.Title = textBoxTitle.Text;
            book.Author = textBoxAuthor.Text;
            book.Category = textBoxCategory.Text;
            if (checkBoxTaken.Checked)
            {
                book.DateTaken = dateTimePickerTaken.Value;
                book.DateReturned = dateTimePickerReturn.Value;
                int cardId = int.Parse(comboBoxTakenByWho.Text.Split(',').ToArray()[0]);
                //this.relationsBusiness.CreateRelation(book, cardBusiness.GetAllCards().Where(x => x.Id == cardId).First());
            }
            else
            {
                book.DateTaken = null;
                book.DateReturned = null;
            }

            
            bookBusiness.UpdateBook(book);
            UpdateGrid();
            dataGridViewBooks.Enabled = true;
            buttonEditBook.Visible = true;
            buttonSaveBook.Visible = false;
        }
    }
}
