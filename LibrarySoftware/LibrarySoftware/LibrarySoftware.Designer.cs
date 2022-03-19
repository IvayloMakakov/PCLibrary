namespace LibrarySoftware
{
    partial class FormLibrarySoftware
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxSelection = new System.Windows.Forms.ComboBox();
            this.groupBoxBook = new System.Windows.Forms.GroupBox();
            this.comboBoxTakenByWho = new System.Windows.Forms.ComboBox();
            this.labelTakenBy = new System.Windows.Forms.Label();
            this.buttonDeleteBook = new System.Windows.Forms.Button();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.labelIsTaken = new System.Windows.Forms.Label();
            this.checkBoxTaken = new System.Windows.Forms.CheckBox();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.labelDateTaken = new System.Windows.Forms.Label();
            this.dateTimePickerReturn = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTaken = new System.Windows.Forms.DateTimePicker();
            this.textBoxCategory = new System.Windows.Forms.TextBox();
            this.labelCategory = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.buttonSaveBook = new System.Windows.Forms.Button();
            this.buttonEditBook = new System.Windows.Forms.Button();
            this.groupBoxCard = new System.Windows.Forms.GroupBox();
            this.buttonTakeSelected = new System.Windows.Forms.Button();
            this.buttonEditCard = new System.Windows.Forms.Button();
            this.buttonDeleteCard = new System.Windows.Forms.Button();
            this.buttonAddNewCard = new System.Windows.Forms.Button();
            this.labelExpirationDate = new System.Windows.Forms.Label();
            this.labeldateCreated = new System.Windows.Forms.Label();
            this.dateTimePickerExpirationDate = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerDateCreated = new System.Windows.Forms.DateTimePicker();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEgn = new System.Windows.Forms.TextBox();
            this.labelEGN = new System.Windows.Forms.Label();
            this.textBoxFullName = new System.Windows.Forms.TextBox();
            this.labelFullName = new System.Windows.Forms.Label();
            this.buttonSaveCard = new System.Windows.Forms.Button();
            this.dataGridViewBooks = new System.Windows.Forms.DataGridView();
            this.pictureBoxMagnifyingGlass = new System.Windows.Forms.PictureBox();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewCards = new System.Windows.Forms.DataGridView();
            this.comboBoxSearchFor = new System.Windows.Forms.ComboBox();
            this.groupBoxBook.SuspendLayout();
            this.groupBoxCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMagnifyingGlass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSelection
            // 
            this.comboBoxSelection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSelection.Items.AddRange(new object[] {
            "Books",
            "Cards"});
            this.comboBoxSelection.Location = new System.Drawing.Point(395, 12);
            this.comboBoxSelection.Name = "comboBoxSelection";
            this.comboBoxSelection.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSelection.TabIndex = 1;
            this.comboBoxSelection.SelectedIndexChanged += new System.EventHandler(this.comboBoxSelection_SelectedIndexChanged);
            // 
            // groupBoxBook
            // 
            this.groupBoxBook.Controls.Add(this.comboBoxTakenByWho);
            this.groupBoxBook.Controls.Add(this.labelTakenBy);
            this.groupBoxBook.Controls.Add(this.buttonDeleteBook);
            this.groupBoxBook.Controls.Add(this.buttonAddBook);
            this.groupBoxBook.Controls.Add(this.labelIsTaken);
            this.groupBoxBook.Controls.Add(this.checkBoxTaken);
            this.groupBoxBook.Controls.Add(this.labelReturnDate);
            this.groupBoxBook.Controls.Add(this.labelDateTaken);
            this.groupBoxBook.Controls.Add(this.dateTimePickerReturn);
            this.groupBoxBook.Controls.Add(this.dateTimePickerTaken);
            this.groupBoxBook.Controls.Add(this.textBoxCategory);
            this.groupBoxBook.Controls.Add(this.labelCategory);
            this.groupBoxBook.Controls.Add(this.textBoxAuthor);
            this.groupBoxBook.Controls.Add(this.labelAuthor);
            this.groupBoxBook.Controls.Add(this.textBoxTitle);
            this.groupBoxBook.Controls.Add(this.labelTitle);
            this.groupBoxBook.Controls.Add(this.buttonSaveBook);
            this.groupBoxBook.Controls.Add(this.buttonEditBook);
            this.groupBoxBook.Location = new System.Drawing.Point(2, 0);
            this.groupBoxBook.Name = "groupBoxBook";
            this.groupBoxBook.Size = new System.Drawing.Size(354, 374);
            this.groupBoxBook.TabIndex = 2;
            this.groupBoxBook.TabStop = false;
            this.groupBoxBook.Text = "Add book";
            // 
            // comboBoxTakenByWho
            // 
            this.comboBoxTakenByWho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxTakenByWho.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTakenByWho.Location = new System.Drawing.Point(90, 227);
            this.comboBoxTakenByWho.Name = "comboBoxTakenByWho";
            this.comboBoxTakenByWho.Size = new System.Drawing.Size(234, 21);
            this.comboBoxTakenByWho.TabIndex = 20;
            this.comboBoxTakenByWho.Visible = false;
            // 
            // labelTakenBy
            // 
            this.labelTakenBy.AutoSize = true;
            this.labelTakenBy.Location = new System.Drawing.Point(29, 230);
            this.labelTakenBy.Name = "labelTakenBy";
            this.labelTakenBy.Size = new System.Drawing.Size(55, 13);
            this.labelTakenBy.TabIndex = 19;
            this.labelTakenBy.Text = "Taken by:";
            this.labelTakenBy.Visible = false;
            // 
            // buttonDeleteBook
            // 
            this.buttonDeleteBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteBook.Location = new System.Drawing.Point(21, 333);
            this.buttonDeleteBook.Name = "buttonDeleteBook";
            this.buttonDeleteBook.Size = new System.Drawing.Size(303, 31);
            this.buttonDeleteBook.TabIndex = 16;
            this.buttonDeleteBook.Text = "Delete selected book";
            this.buttonDeleteBook.UseVisualStyleBackColor = true;
            this.buttonDeleteBook.Click += new System.EventHandler(this.buttonDeleteBook_Click);
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddBook.Location = new System.Drawing.Point(21, 261);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(303, 31);
            this.buttonAddBook.TabIndex = 15;
            this.buttonAddBook.Text = "Add new book";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // labelIsTaken
            // 
            this.labelIsTaken.AutoSize = true;
            this.labelIsTaken.Location = new System.Drawing.Point(32, 158);
            this.labelIsTaken.Name = "labelIsTaken";
            this.labelIsTaken.Size = new System.Drawing.Size(52, 13);
            this.labelIsTaken.TabIndex = 14;
            this.labelIsTaken.Text = "Is Taken:";
            // 
            // checkBoxTaken
            // 
            this.checkBoxTaken.AutoSize = true;
            this.checkBoxTaken.Location = new System.Drawing.Point(90, 157);
            this.checkBoxTaken.Name = "checkBoxTaken";
            this.checkBoxTaken.Size = new System.Drawing.Size(15, 14);
            this.checkBoxTaken.TabIndex = 13;
            this.checkBoxTaken.UseVisualStyleBackColor = true;
            this.checkBoxTaken.CheckedChanged += new System.EventHandler(this.checkBoxTaken_CheckedChanged);
            // 
            // labelReturnDate
            // 
            this.labelReturnDate.AutoSize = true;
            this.labelReturnDate.Location = new System.Drawing.Point(18, 198);
            this.labelReturnDate.Name = "labelReturnDate";
            this.labelReturnDate.Size = new System.Drawing.Size(66, 13);
            this.labelReturnDate.TabIndex = 12;
            this.labelReturnDate.Text = "Return date:";
            this.labelReturnDate.Visible = false;
            // 
            // labelDateTaken
            // 
            this.labelDateTaken.AutoSize = true;
            this.labelDateTaken.Location = new System.Drawing.Point(113, 158);
            this.labelDateTaken.Name = "labelDateTaken";
            this.labelDateTaken.Size = new System.Drawing.Size(67, 13);
            this.labelDateTaken.TabIndex = 11;
            this.labelDateTaken.Text = "Date Taken:";
            this.labelDateTaken.Visible = false;
            // 
            // dateTimePickerReturn
            // 
            this.dateTimePickerReturn.Enabled = false;
            this.dateTimePickerReturn.Location = new System.Drawing.Point(90, 194);
            this.dateTimePickerReturn.Name = "dateTimePickerReturn";
            this.dateTimePickerReturn.Size = new System.Drawing.Size(234, 20);
            this.dateTimePickerReturn.TabIndex = 4;
            this.dateTimePickerReturn.Visible = false;
            // 
            // dateTimePickerTaken
            // 
            this.dateTimePickerTaken.Location = new System.Drawing.Point(183, 154);
            this.dateTimePickerTaken.Name = "dateTimePickerTaken";
            this.dateTimePickerTaken.Size = new System.Drawing.Size(141, 20);
            this.dateTimePickerTaken.TabIndex = 10;
            this.dateTimePickerTaken.Visible = false;
            this.dateTimePickerTaken.ValueChanged += new System.EventHandler(this.dateTimePickerTaken_ValueChanged);
            // 
            // textBoxCategory
            // 
            this.textBoxCategory.Location = new System.Drawing.Point(90, 114);
            this.textBoxCategory.Name = "textBoxCategory";
            this.textBoxCategory.Size = new System.Drawing.Size(234, 20);
            this.textBoxCategory.TabIndex = 9;
            // 
            // labelCategory
            // 
            this.labelCategory.AutoSize = true;
            this.labelCategory.Location = new System.Drawing.Point(35, 118);
            this.labelCategory.Name = "labelCategory";
            this.labelCategory.Size = new System.Drawing.Size(52, 13);
            this.labelCategory.TabIndex = 8;
            this.labelCategory.Text = "Category:";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Location = new System.Drawing.Point(90, 74);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(234, 20);
            this.textBoxAuthor.TabIndex = 7;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(46, 78);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(41, 13);
            this.labelAuthor.TabIndex = 6;
            this.labelAuthor.Text = "Author:";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(90, 34);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(234, 20);
            this.textBoxTitle.TabIndex = 5;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(54, 38);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(30, 13);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "Title:";
            // 
            // buttonSaveBook
            // 
            this.buttonSaveBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveBook.Location = new System.Drawing.Point(21, 296);
            this.buttonSaveBook.Name = "buttonSaveBook";
            this.buttonSaveBook.Size = new System.Drawing.Size(303, 31);
            this.buttonSaveBook.TabIndex = 21;
            this.buttonSaveBook.Text = "Save";
            this.buttonSaveBook.UseVisualStyleBackColor = true;
            this.buttonSaveBook.Visible = false;
            this.buttonSaveBook.Click += new System.EventHandler(this.buttonSaveBook_Click);
            // 
            // buttonEditBook
            // 
            this.buttonEditBook.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditBook.Location = new System.Drawing.Point(21, 297);
            this.buttonEditBook.Name = "buttonEditBook";
            this.buttonEditBook.Size = new System.Drawing.Size(303, 31);
            this.buttonEditBook.TabIndex = 17;
            this.buttonEditBook.Text = "Edit selected book";
            this.buttonEditBook.UseVisualStyleBackColor = true;
            this.buttonEditBook.Click += new System.EventHandler(this.buttonEditBook_Click);
            // 
            // groupBoxCard
            // 
            this.groupBoxCard.Controls.Add(this.buttonTakeSelected);
            this.groupBoxCard.Controls.Add(this.buttonEditCard);
            this.groupBoxCard.Controls.Add(this.buttonDeleteCard);
            this.groupBoxCard.Controls.Add(this.buttonAddNewCard);
            this.groupBoxCard.Controls.Add(this.labelExpirationDate);
            this.groupBoxCard.Controls.Add(this.labeldateCreated);
            this.groupBoxCard.Controls.Add(this.dateTimePickerExpirationDate);
            this.groupBoxCard.Controls.Add(this.dateTimePickerDateCreated);
            this.groupBoxCard.Controls.Add(this.textBoxEmail);
            this.groupBoxCard.Controls.Add(this.labelEmail);
            this.groupBoxCard.Controls.Add(this.textBoxEgn);
            this.groupBoxCard.Controls.Add(this.labelEGN);
            this.groupBoxCard.Controls.Add(this.textBoxFullName);
            this.groupBoxCard.Controls.Add(this.labelFullName);
            this.groupBoxCard.Controls.Add(this.buttonSaveCard);
            this.groupBoxCard.Location = new System.Drawing.Point(362, 0);
            this.groupBoxCard.Name = "groupBoxCard";
            this.groupBoxCard.Size = new System.Drawing.Size(339, 374);
            this.groupBoxCard.TabIndex = 3;
            this.groupBoxCard.TabStop = false;
            this.groupBoxCard.Text = "Add card";
            // 
            // buttonTakeSelected
            // 
            this.buttonTakeSelected.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonTakeSelected.Location = new System.Drawing.Point(179, 313);
            this.buttonTakeSelected.Name = "buttonTakeSelected";
            this.buttonTakeSelected.Size = new System.Drawing.Size(154, 50);
            this.buttonTakeSelected.TabIndex = 35;
            this.buttonTakeSelected.Text = "Take selected book with the selected card";
            this.buttonTakeSelected.UseVisualStyleBackColor = true;
            this.buttonTakeSelected.Click += new System.EventHandler(this.buttonTakeSelected_Click);
            // 
            // buttonEditCard
            // 
            this.buttonEditCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEditCard.Location = new System.Drawing.Point(179, 276);
            this.buttonEditCard.Name = "buttonEditCard";
            this.buttonEditCard.Size = new System.Drawing.Size(154, 31);
            this.buttonEditCard.TabIndex = 32;
            this.buttonEditCard.Text = "Edit selected card";
            this.buttonEditCard.UseVisualStyleBackColor = true;
            this.buttonEditCard.Click += new System.EventHandler(this.buttonEditCard_Click);
            // 
            // buttonDeleteCard
            // 
            this.buttonDeleteCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteCard.Location = new System.Drawing.Point(19, 313);
            this.buttonDeleteCard.Name = "buttonDeleteCard";
            this.buttonDeleteCard.Size = new System.Drawing.Size(154, 50);
            this.buttonDeleteCard.TabIndex = 31;
            this.buttonDeleteCard.Text = "Delete selected card";
            this.buttonDeleteCard.UseVisualStyleBackColor = true;
            this.buttonDeleteCard.Click += new System.EventHandler(this.buttonDeleteCard_Click);
            // 
            // buttonAddNewCard
            // 
            this.buttonAddNewCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddNewCard.Location = new System.Drawing.Point(19, 276);
            this.buttonAddNewCard.Name = "buttonAddNewCard";
            this.buttonAddNewCard.Size = new System.Drawing.Size(154, 31);
            this.buttonAddNewCard.TabIndex = 30;
            this.buttonAddNewCard.Text = "Add new card";
            this.buttonAddNewCard.UseVisualStyleBackColor = true;
            this.buttonAddNewCard.Click += new System.EventHandler(this.buttonAddNewCard_Click);
            // 
            // labelExpirationDate
            // 
            this.labelExpirationDate.AutoSize = true;
            this.labelExpirationDate.Location = new System.Drawing.Point(5, 214);
            this.labelExpirationDate.Name = "labelExpirationDate";
            this.labelExpirationDate.Size = new System.Drawing.Size(80, 13);
            this.labelExpirationDate.TabIndex = 27;
            this.labelExpirationDate.Text = "Expiration date:";
            // 
            // labeldateCreated
            // 
            this.labeldateCreated.AutoSize = true;
            this.labeldateCreated.Location = new System.Drawing.Point(13, 168);
            this.labeldateCreated.Name = "labeldateCreated";
            this.labeldateCreated.Size = new System.Drawing.Size(72, 13);
            this.labeldateCreated.TabIndex = 26;
            this.labeldateCreated.Text = "Date created:";
            // 
            // dateTimePickerExpirationDate
            // 
            this.dateTimePickerExpirationDate.Enabled = false;
            this.dateTimePickerExpirationDate.Location = new System.Drawing.Point(88, 210);
            this.dateTimePickerExpirationDate.Name = "dateTimePickerExpirationDate";
            this.dateTimePickerExpirationDate.Size = new System.Drawing.Size(141, 20);
            this.dateTimePickerExpirationDate.TabIndex = 18;
            // 
            // dateTimePickerDateCreated
            // 
            this.dateTimePickerDateCreated.Location = new System.Drawing.Point(88, 165);
            this.dateTimePickerDateCreated.Name = "dateTimePickerDateCreated";
            this.dateTimePickerDateCreated.Size = new System.Drawing.Size(141, 20);
            this.dateTimePickerDateCreated.TabIndex = 25;
            this.dateTimePickerDateCreated.ValueChanged += new System.EventHandler(this.dateTimePickerDateCreated_ValueChanged);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Location = new System.Drawing.Point(88, 120);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(234, 20);
            this.textBoxEmail.TabIndex = 24;
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(50, 122);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(35, 13);
            this.labelEmail.TabIndex = 23;
            this.labelEmail.Text = "Email:";
            // 
            // textBoxEgn
            // 
            this.textBoxEgn.Location = new System.Drawing.Point(88, 75);
            this.textBoxEgn.Name = "textBoxEgn";
            this.textBoxEgn.Size = new System.Drawing.Size(234, 20);
            this.textBoxEgn.TabIndex = 22;
            // 
            // labelEGN
            // 
            this.labelEGN.AutoSize = true;
            this.labelEGN.Location = new System.Drawing.Point(52, 76);
            this.labelEGN.Name = "labelEGN";
            this.labelEGN.Size = new System.Drawing.Size(33, 13);
            this.labelEGN.TabIndex = 21;
            this.labelEGN.Text = "EGN:";
            // 
            // textBoxFullName
            // 
            this.textBoxFullName.Location = new System.Drawing.Point(88, 30);
            this.textBoxFullName.Name = "textBoxFullName";
            this.textBoxFullName.Size = new System.Drawing.Size(234, 20);
            this.textBoxFullName.TabIndex = 20;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Location = new System.Drawing.Point(30, 30);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(55, 13);
            this.labelFullName.TabIndex = 19;
            this.labelFullName.Text = "Full name:";
            // 
            // buttonSaveCard
            // 
            this.buttonSaveCard.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonSaveCard.Location = new System.Drawing.Point(179, 276);
            this.buttonSaveCard.Name = "buttonSaveCard";
            this.buttonSaveCard.Size = new System.Drawing.Size(154, 31);
            this.buttonSaveCard.TabIndex = 36;
            this.buttonSaveCard.Text = "Save";
            this.buttonSaveCard.UseVisualStyleBackColor = true;
            this.buttonSaveCard.Visible = false;
            this.buttonSaveCard.Click += new System.EventHandler(this.buttonSaveCard_Click);
            // 
            // dataGridViewBooks
            // 
            this.dataGridViewBooks.AllowUserToAddRows = false;
            this.dataGridViewBooks.AllowUserToDeleteRows = false;
            this.dataGridViewBooks.AllowUserToResizeColumns = false;
            this.dataGridViewBooks.AllowUserToResizeRows = false;
            this.dataGridViewBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBooks.Location = new System.Drawing.Point(372, 46);
            this.dataGridViewBooks.Name = "dataGridViewBooks";
            this.dataGridViewBooks.ReadOnly = true;
            this.dataGridViewBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewBooks.Size = new System.Drawing.Size(408, 161);
            this.dataGridViewBooks.TabIndex = 4;
            // 
            // pictureBoxMagnifyingGlass
            // 
            this.pictureBoxMagnifyingGlass.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBoxMagnifyingGlass.Image = global::LibrarySoftware.Properties.Resources.searchTransparent;
            this.pictureBoxMagnifyingGlass.Location = new System.Drawing.Point(571, 12);
            this.pictureBoxMagnifyingGlass.Name = "pictureBoxMagnifyingGlass";
            this.pictureBoxMagnifyingGlass.Size = new System.Drawing.Size(19, 20);
            this.pictureBoxMagnifyingGlass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxMagnifyingGlass.TabIndex = 8;
            this.pictureBoxMagnifyingGlass.TabStop = false;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(596, 12);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(168, 20);
            this.textBoxSearch.TabIndex = 7;
            this.textBoxSearch.TextChanged += new System.EventHandler(this.textBoxSearch_TextChanged);
            // 
            // dataGridViewCards
            // 
            this.dataGridViewCards.AllowUserToAddRows = false;
            this.dataGridViewCards.AllowUserToDeleteRows = false;
            this.dataGridViewCards.AllowUserToResizeColumns = false;
            this.dataGridViewCards.AllowUserToResizeRows = false;
            this.dataGridViewCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewCards.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewCards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCards.Location = new System.Drawing.Point(372, 206);
            this.dataGridViewCards.Name = "dataGridViewCards";
            this.dataGridViewCards.ReadOnly = true;
            this.dataGridViewCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCards.Size = new System.Drawing.Size(408, 168);
            this.dataGridViewCards.TabIndex = 9;
            // 
            // comboBoxSearchFor
            // 
            this.comboBoxSearchFor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSearchFor.DropDownWidth = 80;
            this.comboBoxSearchFor.FormattingEnabled = true;
            this.comboBoxSearchFor.Items.AddRange(new object[] {
            "Search books",
            "Search cards"});
            this.comboBoxSearchFor.Location = new System.Drawing.Point(764, 12);
            this.comboBoxSearchFor.Name = "comboBoxSearchFor";
            this.comboBoxSearchFor.Size = new System.Drawing.Size(18, 21);
            this.comboBoxSearchFor.TabIndex = 10;
            // 
            // FormLibrarySoftware
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 377);
            this.Controls.Add(this.groupBoxCard);
            this.Controls.Add(this.comboBoxSearchFor);
            this.Controls.Add(this.dataGridViewCards);
            this.Controls.Add(this.pictureBoxMagnifyingGlass);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dataGridViewBooks);
            this.Controls.Add(this.comboBoxSelection);
            this.Controls.Add(this.groupBoxBook);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(812, 416);
            this.MinimumSize = new System.Drawing.Size(812, 416);
            this.Name = "FormLibrarySoftware";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Library Software";
            this.Load += new System.EventHandler(this.FormLibrarySoftware_Load);
            this.groupBoxBook.ResumeLayout(false);
            this.groupBoxBook.PerformLayout();
            this.groupBoxCard.ResumeLayout(false);
            this.groupBoxCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMagnifyingGlass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCards)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBoxSelection;
        private System.Windows.Forms.GroupBox groupBoxBook;
        private System.Windows.Forms.GroupBox groupBoxCard;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.DateTimePicker dateTimePickerReturn;
        private System.Windows.Forms.DateTimePicker dateTimePickerTaken;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.Label labelDateTaken;
        private System.Windows.Forms.CheckBox checkBoxTaken;
        private System.Windows.Forms.Button buttonEditBook;
        private System.Windows.Forms.Button buttonDeleteBook;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.Label labelIsTaken;
        private System.Windows.Forms.Button buttonEditCard;
        private System.Windows.Forms.Button buttonDeleteCard;
        private System.Windows.Forms.Button buttonAddNewCard;
        private System.Windows.Forms.Label labelExpirationDate;
        private System.Windows.Forms.Label labeldateCreated;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpirationDate;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateCreated;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEgn;
        private System.Windows.Forms.Label labelEGN;
        private System.Windows.Forms.TextBox textBoxFullName;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.DataGridView dataGridViewBooks;
        private System.Windows.Forms.PictureBox pictureBoxMagnifyingGlass;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewCards;
        private System.Windows.Forms.ComboBox comboBoxTakenByWho;
        private System.Windows.Forms.Label labelTakenBy;
        private System.Windows.Forms.ComboBox comboBoxSearchFor;
        private System.Windows.Forms.Button buttonTakeSelected;
        private System.Windows.Forms.Button buttonSaveBook;
        private System.Windows.Forms.Button buttonSaveCard;
    }
}

