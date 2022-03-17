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
            }
            else
            {
                book.DateTaken = null;
                book.DateReturned = null;
            }
            /*int index = comboBoxTakenByWho.SelectedIndex;
            BookCardRelations relations = new BookCardRelations();
            relations.Book = book;
            relations.LibraryCard = business.GetAllCards()[index];
            book.BookCardRelations.Add(relations);*/
            

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
            List<int> deletedIndexes = new List<int>();
            for (int i = 0; i < dataGridViewBooks.SelectedRows.Count; i++)
            {
                deletedIndexes.Add(dataGridViewBooks.SelectedCells[i].RowIndex);
            }
            foreach (var item in deletedIndexes)
            {

            }
        }

        private void FormLibrarySoftware_Load(object sender, EventArgs e)
        {

        }
    }
}
