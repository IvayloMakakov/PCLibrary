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
    /// <summary>
    /// Represents the set of functionality of the GUI elements at program startup
    /// </summary>
    public partial class FormLibrarySoftware : Form
    {
        public BookBusiness bookBusiness;
        public LibraryCardBusiness cardBusiness;
        public BookCardRelationsBusiness relationsBusiness;
        private int selectedId;
        private int selectedIndex;

        /// <summary>
        /// Updates data in data grids
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        private void UpdateGrid()
        {
            try
            {
                this.dataGridViewBooks.DataSource = this.bookBusiness.GetAllBooks();

                dataGridViewBooks.Columns["TakenBy"].DisplayIndex = dataGridViewBooks.Columns.Count - 2;

                for (int i = 0; i < this.dataGridViewBooks.Rows.Count; i++)
                {
                    int currentBookId = (int)dataGridViewBooks.Rows[i].Cells[1].Value;
                    LibraryCard libraryCard = relationsBusiness.GetLastLibraryCardByBookId(currentBookId);

                    if (libraryCard != null)
                    {
                        dataGridViewBooks.Rows[i].Cells["TakenBy"].Value = libraryCard.EGN;
                    }

                }


                this.dataGridViewCards.DataSource = this.cardBusiness.GetAllCards();
                dataGridViewCards.Columns["TakenBook"].DisplayIndex = dataGridViewCards.Columns.Count - 2;

                for (int i = 0; i < this.dataGridViewCards.Rows.Count; i++)
                {
                    int currentCardId = (int)dataGridViewCards.Rows[i].Cells[1].Value;
                    Book book = relationsBusiness.GetLastBookByLibraryCard(currentCardId);

                    if (book != null)
                    {
                        dataGridViewCards.Rows[i].Cells["TakenBook"].Value = book.Title;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when updating data grid.");
                Application.Exit();
            }
        }
        /// <summary>
        /// Initiates a new instance of the FormLibrarySoftware class by setting specific initial values 
        /// </summary>
        public FormLibrarySoftware()
        {
            InitializeComponent();
            comboBoxSelection.SelectedIndex = 0;
            this.bookBusiness = new BookBusiness();
            this.cardBusiness = new LibraryCardBusiness();
            this.relationsBusiness = new BookCardRelationsBusiness();
            foreach (var card in this.cardBusiness.GetAllCards())
            {
                comboBoxTakenByWho.Items.Add(card.Id + ", " + card.FullName);
            }
            this.SetDates();
            foreach (LibraryCard card in cardBusiness.GetAllCards())
            {
                cardBusiness.DeleteExpiredCard(card);
            }
            if (cardBusiness.GetAllCards().Count > 0)
            {
                comboBoxSearchFor.SelectedIndex = 0;
            }



            dataGridViewBooks.Columns.Add("TakenBy", "CurrentlyTakenBy");
            dataGridViewCards.Columns.Add("TakenBook", "LastBookTaken");
            //
            //
            this.UpdateGrid();
        }
        /// <summary>
        /// Changes the data entry form according to the selected criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Adds additional date entry fields depending on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Adds an additional 30 days from the entered date to the deadline
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePickerTaken_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerReturn.Value = dateTimePickerTaken.Value.AddDays(30);
        }
        /// <summary>
        /// Adds an additional 1 year from the entered date to the expiration date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimePickerDateCreated_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerExpirationDate.Value = dateTimePickerDateCreated.Value.AddYears(1);
        }
        /// <summary>
        /// Sets appropriate values to the expiration date and return date
        /// </summary>
        private void SetDates()
        {
            dateTimePickerReturn.Value = dateTimePickerTaken.Value.AddDays(30);
            dateTimePickerExpirationDate.Value = dateTimePickerDateCreated.Value.AddYears(1);
        }
        /// <summary>
        /// Adds a book to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="System.Exception"></exception>
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
                    //dataGridViewBooks.Rows[dataGridViewBooks.Rows.Count - 1].Cells["TakenBy"].Value = (object)libraryCard.EGN;
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
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the add book button.", "Try again");
                Application.Exit();
            }

        }
        /// <summary>
        /// Adds a card to the database
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        private void buttonAddNewCard_Click(object sender, EventArgs e)
        {
            try
            {
                LibraryCard card = new LibraryCard();

                card.FullName = textBoxFullName.Text;

                //Промяна
                int.Parse(textBoxEgn.Text);
                if (textBoxEgn.Text.Length != 10) throw new ArgumentException("EGN must be 10 characters");


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
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the add new card button.", "Try again");
                Application.Exit();
            }

        }
        /// <summary>
        /// Deletes a book from database
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.bookBusiness.GetAllBooks().Count > 0)
                {
                    DataGridViewCellCollection row = dataGridViewBooks.SelectedRows[0].Cells;
                    this.selectedId = (int)row[1].Value;
                    bookBusiness.DeleteBook(this.selectedId);
                    UpdateGrid();
                    dataGridViewBooks.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the delete book button.");
                Application.Exit();
            }

        }
        /// <summary>
        /// Deletes a card from database
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        private void buttonDeleteCard_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.cardBusiness.GetAllCards().Count > 0)
                {
                    DataGridViewCellCollection row = dataGridViewCards.SelectedRows[0].Cells;
                    this.selectedId = (int)row[1].Value;
                    cardBusiness.DeleteCard(this.selectedId);
                    UpdateGrid();
                    dataGridViewBooks.ClearSelection();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the delete card button.");
                Application.Exit();
            }
        }
        /// <summary>
        /// Sets default values
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLibrarySoftware_Load(object sender, EventArgs e)
        {
            try
            {
                if (this.bookBusiness.GetAllBooks().Count > 0)
                {
                    buttonEditBook.PerformClick();
                    buttonSaveBook.PerformClick(); 
                }
                else
                {
                    textBoxFullName.Text = null;
                    textBoxEgn.Text = null;
                    textBoxEmail.Text = null;
                    dateTimePickerDateCreated.Value = DateTime.Today;

                    textBoxTitle.Text = null;
                    textBoxAuthor.Text = null;
                    textBoxCategory.Text = null;
                    dateTimePickerTaken.Value = DateTime.Today;
                    if (this.cardBusiness.GetAllCards().Count > 0)
                    {
                        comboBoxTakenByWho.SelectedIndex = 0;
                    }

                    SetDates();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when loading the form.");
                Application.Exit();
            }
        }
        /// <summary>
        /// Edits a book from database
        /// </summary>
        private void buttonEditBook_Click(object sender, EventArgs e)
        {
            try
            {
                //ПРОМЯНА
                buttonAddBook.Visible = false;
                buttonDeleteBook.Visible = false;
                if (dataGridViewBooks.SelectedRows.Count > 0)
                {
                    var item = dataGridViewBooks.SelectedRows[0].Cells;
                    this.selectedId = (int)item[1].Value;
                    this.selectedIndex = this.bookBusiness.GetAllBooks().IndexOf(this.bookBusiness.GetBookWithId(selectedId));
                    UpdateTextBoxesBooks(this.selectedId);
                    buttonEditBook.Visible = false;
                    buttonSaveBook.Visible = true;
                    dataGridViewBooks.Enabled = false;
                    UpdateGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when editing a card.");
                Application.Exit();
            }
        }

        /// <summary>
        /// Updates text boxes from book form
        /// </summary>
        private void UpdateTextBoxesBooks(int id)
        {
            Book book = this.bookBusiness.GetBookWithId(id);
            textBoxTitle.Text = book.Title;
            textBoxAuthor.Text = book.Author;
            textBoxCategory.Text = book.Category;
            if (checkBoxTaken.Checked)
            {
                dateTimePickerTaken.Value = book.DateTaken.Value;
                comboBoxTakenByWho.SelectedIndex = cardBusiness.GetAllCards().IndexOf(cardBusiness.GetAllCards().Where(x => x.EGN == (string)dataGridViewBooks.SelectedRows[0].Cells["TakenBy"].Value).First());
            }
            else
            {
                dateTimePickerTaken.Value = DateTime.Today;
            }
            SetDates();
        }
        /// <summary>
        /// Edits a card from database
        /// </summary>
        /// <exception cref="System.Exception"></exception>
        private void buttonEditCard_Click(object sender, EventArgs e)
        {
            try
            {


                //ПРОМЯНА
                buttonAddNewCard.Visible = false;
                buttonDeleteCard.Visible = false;
                buttonTakeSelected.Visible = false;
                if (dataGridViewCards.SelectedRows.Count > 0)
                {
                    var item = dataGridViewCards.SelectedRows[0].Cells;
                    this.selectedId = (int)item[1].Value;
                    this.selectedIndex = this.cardBusiness.GetAllCards().IndexOf(this.cardBusiness.GetCardWithId(selectedId));
                    UpdateTextBoxesCards(this.selectedId);
                    buttonEditCard.Visible = false;
                    buttonSaveCard.Visible = true;
                    dataGridViewCards.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the edit card button.");
                Application.Exit();
            }
        }
        private void ClearTextBoxes()
        {
            textBoxTitle.Text = null;
            textBoxAuthor.Text = null;
            textBoxCategory.Text = null;
            checkBoxTaken.Checked = false;
            dateTimePickerTaken.Value = DateTime.Today;
            comboBoxTakenByWho.SelectedIndex = 0;

            textBoxFullName.Text = null;
            textBoxEgn.Text = null;
            textBoxEmail.Text = null;
            dateTimePickerDateCreated.Value = DateTime.Today;

            SetDates();
        }


        /// <summary>
        /// Updates text boxes from card form
        /// </summary>
        private void UpdateTextBoxesCards(int id)
        {
            LibraryCard card = this.cardBusiness.GetCardWithId(id);
            textBoxFullName.Text = card.FullName;
            textBoxEgn.Text = card.EGN;
            textBoxEmail.Text = card.Email;
            dateTimePickerDateCreated.Value = card.DateCreated;
            dateTimePickerExpirationDate.Value = card.ExpirationDate;
        }
        /// <summary>
        /// Saves all entered information from the book form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveBook_Click(object sender, EventArgs e)
        {
            try
            {


                Book book = new Book();
                book.BookId = selectedId;
                book.Title = textBoxTitle.Text;
                book.Author = textBoxAuthor.Text;
                book.Category = textBoxCategory.Text;
                if (checkBoxTaken.Checked)
                {
                    book.DateTaken = dateTimePickerTaken.Value;
                    book.DateReturned = dateTimePickerReturn.Value;
                    BookCardRelations editedRelations = new BookCardRelations();
                    editedRelations.BookId = book.BookId;
                    editedRelations.LibraryCardId = int.Parse(comboBoxTakenByWho.SelectedItem.ToString().Split(',').ToArray()[0]);
                    relationsBusiness.CreateRelation(editedRelations);
                }
                else
                {
                    book.DateTaken = null;
                    book.DateReturned = null;
                }


                bookBusiness.UpdateBook(book);
                UpdateGrid();
                ClearTextBoxes();
                dataGridViewBooks.Enabled = true;
                buttonEditBook.Visible = true;
                buttonSaveBook.Visible = false;
                //ПРОМЯНА
                buttonAddBook.Visible = true;
                buttonDeleteBook.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the save book button.");
                Application.Exit();
            }
        }
        /// <summary>
        /// Initializes data source by returning a List<Book> collection
        /// </summary>
        /// <param name="searchedString"></param>
        private void BookSearch(string searchedString)
        {
            dataGridViewBooks.DataSource = bookBusiness.SearchBooks(searchedString);
        }
        /// <summary>
        /// Initializes data source by returning a List<LibraryCard> collection
        /// </summary>
        /// <param name="searchedString"></param>
        private void CardSearch(string searchedString)
        {
            dataGridViewCards.DataSource = cardBusiness.SearchCards(searchedString);
        }
        /// <summary>
        /// Filters the selected data grid according to the selected criteria
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (comboBoxSearchFor.SelectedIndex == 0)
            {
                BookSearch(textBoxSearch.Text);
            }
            else
            {
                CardSearch(textBoxSearch.Text);
            }

        }
        /// <summary>
        /// Gets selected row and creates a relation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTakeSelected_Click(object sender, EventArgs e)
        {
            DataGridViewCellCollection row = dataGridViewBooks.SelectedRows[0].Cells;
            int bookId = (int)row[1].Value;
            DataGridViewCellCollection rowCard = dataGridViewCards.SelectedRows[0].Cells;
            int cardId = (int)rowCard[1].Value;

            bookBusiness.GetBookWithId(bookId).DateTaken = DateTime.Today;
            bookBusiness.GetBookWithId(bookId).DateReturned = DateTime.Today.AddDays(30);

            BookCardRelations relations = new BookCardRelations();
            relations.BookId = bookId;
            relations.LibraryCardId = cardId;

            relationsBusiness.CreateRelation(relations);

            UpdateGrid();
        }

        /// <summary>
        /// Saves the edited card
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSaveCard_Click(object sender, EventArgs e)
        {
            try
            {


                LibraryCard card = new LibraryCard();
                card.Id = selectedId;
                card.FullName = textBoxFullName.Text;

                card.EGN = textBoxEgn.Text;
                card.Email = textBoxEmail.Text;
                card.DateCreated = dateTimePickerDateCreated.Value;
                card.ExpirationDate = dateTimePickerExpirationDate.Value;




                cardBusiness.UpdateCard(card);
                UpdateGrid();
                ClearTextBoxes();
                dataGridViewCards.Enabled = true;
                buttonEditCard.Visible = true;
                buttonSaveCard.Visible = false;

                buttonAddNewCard.Visible = true;
                buttonDeleteCard.Visible = true;
                buttonTakeSelected.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"The error \"{ex.Message}\" is the cause of the failed operation when clicking the save card button.");
                Application.Exit();
            }
        }
    }
}
