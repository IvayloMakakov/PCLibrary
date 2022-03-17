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
        public LibraryBusiness business;

        public FormLibrarySoftware()
        {
            InitializeComponent();
            comboBoxSelection.SelectedIndex = 0;
            this.business = new LibraryBusiness();
            this.UpdateGrid();
            foreach (var card in this.business.GetAllCards())
            {
                comboBoxTakenByWho.Items.Add(card.Id + ", " + card.FullName);
            }
            this.SetDates();
            foreach (LibraryCard card in business.GetAllCards())
            {
                business.DeleteExpiredCard(card);
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
            Book book = new Book();
            book.Title = textBoxTitle.Text;
            book.Author = textBoxAuthor.Text;
            book.Category = textBoxCategory.Text;
            if (checkBoxTaken.Checked)
            {
                book.DateTaken = dateTimePickerTaken.Value;
                book.DateReturned = dateTimePickerReturn.Value;
                int cardId = int.Parse(comboBoxTakenByWho.Text.Split(',').ToArray()[0]);
                this.business.CreateRelation(book, business.GetAllCards().Where(x => x.Id == cardId).First());
            }
            else
            {
                book.DateTaken = null;
                book.DateReturned = null;
            }
            

            business.AddBook(book);
            UpdateGrid();
        }

        private void UpdateGrid()
        {
            this.dataGridViewBooks.DataSource = this.business.GetAllBooks();
            this.dataGridViewCards.DataSource = this.business.GetAllCards();
        }

        private void buttonAddNewCard_Click(object sender, EventArgs e)
        {
            LibraryCard card = new LibraryCard();

            card.FullName = textBoxFullName.Text;
            card.EGN = textBoxEgn.Text;
            card.Email = textBoxEmail.Text;
            card.DateCreated = dateTimePickerDateCreated.Value;
            card.ExpirationDate = dateTimePickerExpirationDate.Value;

            this.business.AddCard(card);
            UpdateGrid();
            comboBoxTakenByWho.Items.Add(card.Id + ", " + card.FullName);
        }

        private void pictureBoxMagnifyingGlass_Click(object sender, EventArgs e)
        {

        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection row = dataGridViewBooks.SelectedRows[0].Cells;
            int id = (int)row[0].Value;
            business.DeleteBook(id);
            UpdateGrid();
            dataGridViewBooks.ClearSelection();
        }

        private void dataGridViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buttonDeleteCard_Click(object sender, EventArgs e)
        {            
            DataGridViewCellCollection row = dataGridViewCards.SelectedRows[0].Cells;
            int id = (int)row[0].Value;
            business.DeleteCard(id);
            UpdateGrid();
            dataGridViewBooks.ClearSelection();
        }
    }
}
